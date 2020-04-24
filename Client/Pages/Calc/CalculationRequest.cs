using System;
using System.Collections.Generic;

namespace TKZ.Client.Pages.Calc
{
    /// <summary>
    /// Wrap on calculation node input.
    /// </summary>
    public class CalculationRequest
    {
        //TODO: После реализации модели коллекции узлов - дописать класс

        /// <summary>
        /// Collection of oninput generated integers (nodes)
        /// </summary>
        public string Request { get; set; } = String.Empty;

        /// <summary>
        /// Convert non-empty request into List of Integers
        /// </summary>
        /// <returns>List of Integers related to the Request property</returns>
        public List<int> GetList()
        {
            if (!String.IsNullOrEmpty(this.Request))
            {
                List<int> outputIntegers = new List<int>();

                foreach (string item in this.Request.Split(",")) outputIntegers.Add(Convert.ToInt32(item));

                return outputIntegers;
            }
            else return new List<int>();
        }

        /// <summary>
        ///Return List of Integers related to the current Node collection
        /// </summary>
        /// <returns></returns>
        public List<int> GetActiveNodes()   //TODO
        {
            throw new NotImplementedException();
        }
    }
}