using RLBPulse.GlobalBenchmarking.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RLBPulse.GlobalBenchmarking.Models
{
    public enum SupportedOutputs
    {
        XML = 1,
        CSV = 2,
        Summary = 3,
        PARAMETER_GRID = 4,
        VARIABLE_GRID = 5
    }
    public class KendoReadableColumn
    {
        public string Field { get; set; }
        public string Tooltip { get; set; }
        public bool Fixed { get; set; }
    }
    /// <summary>
    /// A way to describe rows and columns with Column based statistics
    /// that can easily mapo to a Kendo Grid
    /// </summary>
    public class  DynamicGridModel
    {
        public List<KendoReadableColumn> Columns { get; set; }
        public List<Dictionary<string, string>> Rows { get; set; }

        private Dictionary<string, int> _rowLookup;

        private Dictionary<string, List<double>> _rowAggregation;
        public int depth { get; set; }

        public DynamicGridModel()
        {
            Columns = new List<KendoReadableColumn>();
            Rows = new List<Dictionary<string, string>>();
            _rowLookup = new Dictionary<string, int>();
            _rowAggregation = new Dictionary<string, List<double>>();
        }

        public void FixColumn(string columnName)
        {
            var found = this.Columns.Find(x => x.Field == columnName);
            if( found != default)
            {
                found.Fixed = true;
            }
        }
        public void AddRow(string identifier, bool withAggregation = false)
        {
            this.Rows.Add(new Dictionary<string, string>());
            if(!this._rowLookup.ContainsKey(identifier) )
            {
                this._rowLookup.Add(identifier, this.Rows.Count - 1);
            }
            
            if( withAggregation)
            {
                if (!this._rowAggregation.ContainsKey(identifier))
                {
                    this._rowAggregation.Add(identifier, new List<double>());
                }                    
            }
        }
        public bool AddCellValue(string rowIdentifier, string columnIdentifier, string value)
        {
            if( this._rowLookup.ContainsKey(rowIdentifier))
            {
                var index = -1;
                if( this._rowLookup.TryGetValue(rowIdentifier, out index) ){
                    if( this.Columns.FindIndex(x  => x.Field == columnIdentifier) != -1 )
                    {
                        if( this.Rows[index].ContainsKey(columnIdentifier))
                        {
                            this.Rows[index][columnIdentifier] = value;
                        } else
                        {
                            this.Rows[index].Add(columnIdentifier, value);
                        }
                        
                        return true;
                    }                    
                }                
            }
            return false;            
        }
        public void AddValueToAggregation(string rowIdentifier, decimal value)
        {
            List<double> indices;
            if( this._rowAggregation.TryGetValue(rowIdentifier, out indices) ){
                indices.Add((double)value);
            }            
        }
        public ExemplarStatisticsSet AggregateRow(string rowIdentifier)
        {
            List<double> indices;
            if (this._rowAggregation.TryGetValue(rowIdentifier, out indices))
            {
                if( indices.Count == 0)
                {
                    return null;
                }
                var sum = indices.Sum();
                var avg = indices.Average();
                var max = indices.Max();
                var min = indices.Min();
                double sumDiff = indices.Sum(d => Math.Pow(d - avg, 2));
                var sd = indices.Count == 1 ? 0 : Math.Sqrt(sumDiff / (indices.Count() - 1) );
                var median = GetMedian(indices.ToArray());
                double leftQuartile = 0;
                double rightQuartile = 0;
                try
                {
                    leftQuartile = GetMedian(indices.Where(x => x < median).ToArray());
                    rightQuartile = GetMedian(indices.Where(x => x > median).ToArray());
                }
                catch( Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                return new ExemplarStatisticsSet()
                {
                    MaxValue = (decimal)max,
                    MinValue = (decimal)min,
                    MeanValue = (decimal)avg,
                    MedianValue = (decimal)median,
                    StandardDeviation = (decimal)sd,
                    LeftQuartile = (decimal)leftQuartile,
                    RightQuartile = (decimal)rightQuartile
                };
            }
            return null;
        }
        /// <summary>
        /// Move to Math functions / library
        /// </summary>
        /// <param name="sourceNumbers"></param>
        /// <returns></returns>
        public double GetMedian(double[] sourceNumbers)
        {
            //Framework 2.0 version of this method. there is an easier way in F4        
            if (sourceNumbers == null || sourceNumbers.Length == 0)
                throw new Exception("Median of empty array not defined.");

            //make sure the list is sorted, but use a new array
            double[] sortedPNumbers = (double[])sourceNumbers.Clone();
            Array.Sort(sortedPNumbers);

            //get the median
            int size = sortedPNumbers.Length;
            int mid = size / 2;
            double median = (size % 2 != 0) ? (double)sortedPNumbers[mid] : ((double)sortedPNumbers[mid] + (double)sortedPNumbers[mid - 1]) / 2;
            return median;
        }
    }
    
    public class GridInput
    {
        public SupportedOutputs OutputFormat;
        public int depth;
        public int[] SelectedIds;
    }
}
