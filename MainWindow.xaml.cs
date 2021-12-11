using System;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using System.IO;
using System.Collections.Generic;
using LiveCharts.Helpers;
using System.Linq;

namespace Wpf.CartesianChart.PointShapeLine
{
    public partial class PointShapeLineExample : UserControl
    {


        public PointShapeLineExample()
        {
            //InitializeComponent();

            List<int> TagIds = new List<int>();
            List<int> TagIds_1 = new List<int>();

            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            using (var reader = new StreamReader("C:\\Users\\VAO1SI\\Desktop\\MQTT-C-_-main\\MQTTFirstLook.Broker\\bin\\Debug\\net5.0\\Test_Logs_10December.csv"))
            {
                Console.WriteLine(reader.ReadLine());




                while (!reader.EndOfStream)
                //for (int i = 1 ; i < 10; i++)
                {

                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    //values= values[0].Split(@"\\");
                    string output = values[0].TrimStart('{').Replace("\"", "");

                    listA.Add(output.ToString().Substring(output.ToString().LastIndexOf(":") + 1));

                    TagIds = listA.Select(int.Parse).ToList();
                    listA.Select(int.Parse).ToList();
                    Console.WriteLine(listA);



                    //listB.Add(values[1]);
                    string output_1 = values[1].Replace("\"", "").TrimEnd('}');
                    output_1.Split(':');
                    listB.Add(output_1.ToString().Substring(output_1.ToString().LastIndexOf("T") + 1, 5));
                    //TagIds_1 = listB.Select(int.Parse).ToList();
                    //listB.Select(int.Parse).ToList();






                    SeriesCollection = new SeriesCollection
                {
                new LineSeries
                    {
                        Title = "Series 1",
                        Values = TagIds.AsChartValues(),
                    },

                };

                    Labels = (listB);
                    YFormatter = value => value.ToString("C");
                    DataContext = this;
                }

            }

        }

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

    }
}
