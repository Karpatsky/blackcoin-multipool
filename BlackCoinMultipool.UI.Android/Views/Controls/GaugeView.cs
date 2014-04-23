using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Graphics;

namespace BlackCoinMultipool.UI.Android.Views.Controls
{
    public class GaugeView : View
    {
        #region Private Members
        private double _value;
        private double _maxValue = 100.0;
        private float _sweep = 10;
        private string _valueString = "0.0";
        private string _unit;
        private Color _gaugeForeground;
        private Color _background;
        private Color _gaugeBackground;
        private Color _textColor;

        private Paint _textPaint;
        private float _textHeight;
        private Paint _gaugeForegroundPaint;
        private Paint _backgroundPaint;
        private Paint _gaugeBackgroundPaint;

        private RectF _rectGauge = new RectF(0, 0, 0, 0);
        private RectF _rectValueText = new RectF(0, 0, 0, 0);
        private RectF _rectUnitText = new RectF(0, 0, 0, 0);
        #endregion

        #region Public Properties
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value; 
                _sweep = (300f * (float)(_value / _maxValue)) % 300f;
                _valueString = _value.ToString("####.##");                
                // invalidate the view so it will be redrawn
                Invalidate();
            }
        }
        public double MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
                _sweep = (300f * (float)(_value / _maxValue)) % 300f;
                // invalidate the view so it will be redrawn
                Invalidate();
            }
        }
        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
                // invalidate the view so it will be redrawn
                Invalidate();
            }
        }
        #endregion

        /// <summary>
        /// Constructer required for (ADT) Layout Editor compatibility.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="attrs"></param>
        public GaugeView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            var typedArray = context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.GaugeView, 0, 0);

            try
            {
                _value = typedArray.GetFloat(Resource.Styleable.GaugeView_value, 0.0f);
                _maxValue = typedArray.GetFloat(Resource.Styleable.GaugeView_maxValue, 0.0f);
                _unit = typedArray.GetString(Resource.Styleable.GaugeView_unit);
                _gaugeForeground = typedArray.GetColor(Resource.Styleable.GaugeView_gaugeForeground, Color.Red);
                _background = typedArray.GetColor(Resource.Styleable.GaugeView_background, Color.Transparent);
                _gaugeBackground = typedArray.GetColor(Resource.Styleable.GaugeView_gaugeBackground, Color.DarkGray);
                _textColor = typedArray.GetColor(Resource.Styleable.GaugeView_textColor, Color.Red);


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("exception: {0}", ex.Message);
            }
            finally
            {
                typedArray.Recycle();
            }

            Initialize();
        }

        /// <summary>
        /// Does some Paint initialization
        /// </summary>
        private void Initialize()
        {
            _textPaint = new Paint(PaintFlags.AntiAlias | PaintFlags.FakeBoldText);
            _textPaint.Color = _textColor;

            if (_textHeight == 0)
            {
                _textHeight = _textPaint.TextSize;
            }
            else
            {
                _textPaint.TextSize = _textHeight;
            }

            _backgroundPaint = new Paint(PaintFlags.AntiAlias);
            _backgroundPaint.SetStyle(Paint.Style.Fill);
            _backgroundPaint.Color = _background;

            _gaugeForegroundPaint = new Paint(PaintFlags.AntiAlias);
            _gaugeForegroundPaint.SetStyle(Paint.Style.Stroke);
            _gaugeForegroundPaint.StrokeWidth = 100f;
            _gaugeForegroundPaint.Color = _gaugeForeground;

            _gaugeBackgroundPaint = new Paint(PaintFlags.AntiAlias);
            _gaugeBackgroundPaint.SetStyle(Paint.Style.Stroke);
            _gaugeBackgroundPaint.StrokeWidth = 100f;
            _gaugeBackgroundPaint.Color = _gaugeBackground;
        }

        /// <summary>
        /// This method is used to recalculate sizes and offsets to draw
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="oldw"></param>
        /// <param name="oldh"></param>
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            // Determine the textsize
            float textsize = h / 15f;

            // The View should account for padding (y-padding includes textsize for 'unit'-text
            float ww = (float)(w - PaddingLeft - PaddingRight);
            float hh = (float)(h - PaddingTop - PaddingBottom - (textsize * 1.1f));

            // Determine how big the 'circle' can be
            float diameter = Math.Min(ww, hh);

            // Determine the strokewidth (defined as 1/4th of the circle-(outer-)diameter
            float strokewidth = diameter / 5f;
            _gaugeForegroundPaint.StrokeWidth = strokewidth;
            _gaugeBackgroundPaint.StrokeWidth = strokewidth;

            // Correct the diameter to account for the strokewidth
            diameter = diameter - strokewidth;

            // Calculate the padding that is required because width & height most likely are not equal
            float xpadding = (ww - diameter) / 2.0f;
            float ypadding = (hh - diameter) / 2.0f;

            _rectGauge = new RectF(PaddingLeft + xpadding, PaddingTop + ypadding, PaddingLeft + xpadding + diameter, PaddingTop + ypadding + diameter);

            // max width of value text is 0.866 * d ( => cos(30/360*2*PI)*1/2*d )
            // hardcoding cosine value here because cosine function is slow and angle never changes
            float valueTextWidth = (0.866f * (diameter/2f));

            _textPaint.TextSize = textsize;            
            _rectValueText = new RectF(PaddingLeft + xpadding + (diameter - valueTextWidth)/2f, PaddingTop + ypadding + diameter - textsize, PaddingLeft + xpadding + (diameter - valueTextWidth)/2f + valueTextWidth, PaddingTop + ypadding + diameter);
            _rectUnitText = new RectF(0, 0, 0, 0);

            base.OnSizeChanged(w, h, oldw, oldh);

        }

        /// <summary>
        /// The method is used to actually draw the view
        /// </summary>
        /// <param name="canvas"></param>
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            canvas.DrawArc(_rectGauge, 120, 300, false, _gaugeBackgroundPaint);

            canvas.DrawArc(_rectGauge, 120, _sweep, false, _gaugeForegroundPaint);


            if (!string.IsNullOrEmpty(_valueString))
            {
                float textWidth = _textPaint.MeasureText(_valueString);
                canvas.DrawText(_valueString, _rectValueText.Left + (_rectValueText.Width() - textWidth) / 2f, _rectValueText.Bottom, _textPaint);
            }

            if (!string.IsNullOrEmpty(_unit))
            {
                float textWidth = _textPaint.MeasureText(_unit);
                canvas.DrawText(_unit, _rectValueText.Left + (_rectValueText.Width() - textWidth) / 2f, _rectValueText.Bottom + (_rectValueText.Height() * 1.2f), _textPaint);
            }


        }
    }
}