// Copyright (c) 2020 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//

using System;

namespace SoftCircuits.WebScraper
{
    public class UpdateProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets text that describes the current activity.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the current progress as a percent from 0 to 100.
        /// </summary>
        public int Percent { get; set; }

        /// <summary>
        /// Gets or sets whether or not the scan should be aborted.
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// Constructs a new <see cref="UpdateProgressEventArgs"/> instance.
        /// </summary>
        internal UpdateProgressEventArgs()
        {
            Status = string.Empty;
            Percent = 0;
            Cancel = false;
        }

        /// <summary>
        /// Helper static method to calculate the progress percent.
        /// </summary>
        /// <param name="current">Number of items completed.</param>
        /// <param name="total">Total number of items.</param>
        /// <returns>The percent (from 0 to 100).</returns>
        public static int CalculatePercent(int current, int total) => Math.Min((int)(((double)current / total) * 100), 100);
    }
}
