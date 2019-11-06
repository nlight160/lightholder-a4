﻿using System;
using Windows.UI.Xaml;
using FroggerStarter.View.Sprites;

namespace FroggerStarter.Model
{
    /// <summary>
    /// </summary>
    /// <seealso cref="FroggerStarter.Model.StationaryObject" />
    public class InvincibilityPowerUp : StationaryObject
    {
        #region Data members

        private DispatcherTimer invincibilityTimer;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvincibilityPowerUp" /> class.
        /// </summary>
        public InvincibilityPowerUp()
        {
            this.initializeInvincibilityPowerUpSprite();
            this.setupInvincibilityTimer();
        }

        #endregion

        #region Methods

        private void initializeInvincibilityPowerUpSprite()
        {
            Sprite = new InvincibilitySprite();
            X = 350;
            Y = 300;
        }

        private void setupInvincibilityTimer()
        {
            this.invincibilityTimer = new DispatcherTimer();
            this.invincibilityTimer.Tick += this.invincibilityTimerTick;
            this.invincibilityTimer.Interval = new TimeSpan(0, 0, 0, 10, 0);
        }

        private void invincibilityTimerTick(object sender, object e)
        {
            this.invincibilityTimer.Stop();
        }

        /// <summary>
        ///     Starts the bonus time power up timer.
        /// </summary>
        public void StartInvincibilityPowerUpTimer()
        {
            this.invincibilityTimer.Start();
        }

        /// <summary>
        ///     Determines whether [is invincibility active].
        /// </summary>
        /// <returns>
        ///     <c>true</c> if [is invincibility active]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInvincibilityActive()
        {
            return this.invincibilityTimer.IsEnabled;
        }

        #endregion
    }
}