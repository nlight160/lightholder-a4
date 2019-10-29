﻿using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FroggerStarter.View.Sprites
{
    /// <summary>
    ///     Holds common functionality for all game sprites.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.UserControl" />
    public abstract partial class BaseSprite : ISpriteRenderer
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseSprite" /> class.
        /// </summary>
        protected BaseSprite()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Renders user control at the specified (x,y) location in relation
        ///     to the top, left part of the canvas.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void RenderAt(double x, double y)
        {
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);
        }

        /// <summary>
        ///     Reverses the sprite.
        ///     Precondition: None
        ///     PostCondition: Sprite is flipped
        /// </summary>
        public void ReverseSprite()
        {
            RenderTransformOrigin = new Point(0.5, 0.5);
            RenderTransform = new ScaleTransform {ScaleX = -1};
        }

        #endregion
    }
}