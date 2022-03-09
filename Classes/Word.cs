namespace Lab1
{
    /// <summary>
    /// class to store info about word
    /// </summary>
    public class Word
    {
        public string Value { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// constructor with one parameter
        /// </summary>
        /// <param name="value">word</param>
        public Word(string value)
        {
            this.Value = value;
            Count = 0;
        }

        /// <summary>
        /// converts object info to string
        /// </summary>
        /// <returns>formatted string</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Value, this.Count);
        }
    }
}