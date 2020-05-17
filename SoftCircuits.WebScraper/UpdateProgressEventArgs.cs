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
        /// Gets or sets a value that indicates the current item that
        /// is being processed.
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates the maximum number of
        /// items to process.
        /// </summary>
        public int Maximum { get; set; }

        /// <summary>
        /// Gets or sets whether or not the process should be aborted.
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// Constructs a new <see cref="UpdateProgressEventArgs"/> instance.
        /// </summary>
        internal UpdateProgressEventArgs()
        {
            Status = string.Empty;
            Current = Maximum = 0;
            Cancel = false;
        }
    }
}
