using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using NAudio.Wave;
using Meta.Numerics.SignalProcessing;
using Meta.Numerics;
using System.Data.SQLite;


namespace MuzCatalogr
{
    public partial class HOLO : Form
    {
        public HOLO()
        {
            InitializeComponent();
        }

        public struct _song_profile
        {
            public string name;
            public string path;
            public long total_samples;
            public int snap_size;
            public int snap_count;
            public double length;

            public List<List<double>> fft_snaps;
            public List<List<double>> fft_smoothed_snaps;
            public List<List<double>> fft_downscaled_snaps;
            public List<List<double>> fft_downscaled_stdevs;

            public List<List<double>> fft2_snaps;
            public List<List<double>> fft2_smoothed_snaps;
            public List<List<double>> fft2_downscaled_snaps;
            public List<List<double>> fft2_downscaled_stdevs;

            public List<double> snap_correls;
            public List<double> snap_smoothed_correls;
            public List<double> snap_log10_energy;

            public Dictionary<string, double> scalar_stats;
            public Dictionary<string, List<double>> vec_stats;

            public _song_profile(string _name, string _path)
            {
                name = _name;
                path = _path;
                //alglib.kmeansgenerate();

                total_samples = 0;
                length = 0;
                snap_size = 0;
                snap_count = 0;

                fft_snaps = new List<List<double>>();
                fft_smoothed_snaps = new List<List<double>>();
                fft_downscaled_snaps = new List<List<double>>();
                fft_downscaled_stdevs = new List<List<double>>();

                fft2_snaps = new List<List<double>>();
                fft2_smoothed_snaps = new List<List<double>>();
                fft2_downscaled_snaps = new List<List<double>>();
                fft2_downscaled_stdevs = new List<List<double>>();

                snap_correls = new List<double>();
                snap_smoothed_correls = new List<double>();
                snap_log10_energy = new List<double>();

                scalar_stats = new Dictionary<string, double>();
                vec_stats = new Dictionary<string, List<double>>();
            }

            public bool MakeSnaps(int _snapsize, int _snapcount, string _path, int smooth_size)
            {
                try
                {
                    using (Mp3FileReader pcm = new Mp3FileReader(_path))
                    {
                        int samplesDesired = _snapsize;
                        int blockscount = _snapcount;

                        snap_size = _snapsize;
                        snap_count = _snapcount;
                        total_samples = pcm.Length;
                        length = pcm.TotalTime.Seconds;
                        path = _path;

                        if ((pcm.WaveFormat.SampleRate != 44100) || (pcm.WaveFormat.BitsPerSample != 16))
                            return false;

                        for (int i = 0; i < blockscount; i++)
                        {
                            byte[] buffer = new byte[samplesDesired * 4];
                            short[] left = new short[samplesDesired];
                            short[] right = new short[samplesDesired];
                            double[] leftd = new double[samplesDesired];
                            double[] rightd = new double[samplesDesired];

                            int bytesRead = 0;

                            //for (int j = 0; j < 1; j++) ///////////
                            int seek_counter = 0;
                        seek: pcm.Seek((i + 1) * (i + 1) * (i + 1) * blockscount * samplesDesired % (total_samples - samplesDesired), SeekOrigin.Begin);
                            seek_counter++;

                            bytesRead = pcm.Read(buffer, 0, 4 * samplesDesired);

                            int index = 0;
                            for (int sample = 0; sample < bytesRead / 4; sample++)
                            {
                                left[sample] = BitConverter.ToInt16(buffer, index); index += 2;
                                right[sample] = BitConverter.ToInt16(buffer, index); index += 2;
                            }

                            if (left.Average(t => Math.Abs(t)) == 0)
                                if (seek_counter > 5)
                                    return false;
                                else
                                    goto seek;

                            //snap_log10_energy.Add(Math.Log10(left.Average(t => Math.Abs(t))));

                            leftd = Normalize(left, left.Length);
                            rightd = Normalize(right, right.Length);

                            //alglib.complex[] fl;
                            //alglib.fftr1d(leftd, out fl);
                            //fl[0].x;

                            FourierTransformer ft = new FourierTransformer(samplesDesired);
                            var xxa = new Complex[leftd.Length];

                            for (int j = 0; j < leftd.Length; j++)
                                xxa[j] = new Complex(leftd[j], rightd[j]);

                            var ftt = ft.Transform(xxa);

                            List<double> pow_re_im = new List<double>();
                            //List<double> arg_re_im = new List<double>();

                            ftt.ToList().ForEach(t => pow_re_im.Add(ComplexMath.Abs(t)));
                            //ftt.ToList().ForEach(t => arg_re_im.Add(ComplexMath.Arg(t)));

                            /*if (Double.IsNaN(MC_Log10_Energy(pow_re_im)))
                                if (seek_counter > 5)
                                    return false;
                                else
                                    goto seek;*/

                            fft_snaps.Add(pow_re_im);
                            //fft_smoothed_snaps.Add(Smoothen(pow_re_im, smooth_size));

                            //pow_re_im = Normalize(pow_re_im);

                            /*
                            var f_pwri = pow_re_im.Average(t => Math.Abs(t));
                            for (int k = 0; k < pow_re_im.Count; k++)
                                pow_re_im[k] = (Math.Abs(pow_re_im[k]) >= f_pwri * 1.5) ? pow_re_im[k] : 0;
                            */

                            /*
                            FourierTransformer ft2 = new FourierTransformer(samplesDesired);
                            var xx2 = new List<Complex>();
                            for (int j = 0; j < pow_re_im.Count; j++)
                            {
                                xx2.Add(new Complex(pow_re_im[j], arg_re_im[j]));
                            }
                            var ftt2 = ft2.Transform(xx2);
                            //var ftt2 = ft2.Transform(ftt);

                            List<double> pow_re_im2 = new List<double>();
                            ftt2.ToList().ForEach(t => pow_re_im2.Add(ComplexMath.Abs(t)));
                            pow_re_im2 = Normalize(pow_re_im2);
                            fft2_snaps.Add(pow_re_im2);
                            fft2_smoothed_snaps.Add(Smoothen(pow_re_im2, smooth_size));
                            */
                        }
                        pcm.Close();
                    }
            }
            catch (Exception e)
            {
                return false;
            }

                return true;
            }

            public void MakeDownscaledSnaps(int ratio)
            {
                int tgtsize = (fft_snaps[0].Count / ratio);
                int snapsize = fft_snaps[0].Count;

                foreach (var k in fft_snaps)
                {
                    var v = new List<double>();
                    //var w = new List<double>();

                    if (ratio != 1)
                    {
                        for (int i = 0; i < tgtsize; i++)
                        {
                            var vk = k.GetRange(i * ratio, ratio);
                            var s_mean = vk.Average();
                            //var s_geom_mean = Math.Pow(10, vk.Average(t => Math.Log10(t)));
                            //var s_diff = Math.Sqrt(vk.Sum(t => Math.Pow(t - s_mean, 2)) / ratio);

                            v.Add(s_mean);
                            //w.Add(s_diff);
                        }
                        fft_downscaled_snaps.Add(v);
                        //fft_downscaled_stdevs.Add(w);
                    }
                    else
                        fft_downscaled_snaps.Add(k);
                }
            }

            public void MakeDownscaledSnaps2(int ratio)
            {
                int tgtsize = (fft2_snaps[0].Count / ratio);
                int snapsize = fft2_snaps[0].Count;

                foreach (var k in fft2_snaps)
                {
                    var v = new List<double>();
                    var w = new List<double>();

                    for (int i = 0; i < tgtsize; i++)
                    {
                        var vk = k.GetRange(i * ratio, ratio);
                        var s_mean = vk.Average();
                        var s_diff = Math.Sqrt(vk.Sum(t => Math.Pow(t - s_mean, 2)) / ratio);

                        v.Add(s_mean);
                        w.Add(s_diff);
                    }
                    fft2_downscaled_snaps.Add(v);
                    fft2_downscaled_stdevs.Add(w);
                }
            }

            public void CalcInternalCorrels()
            {
                snap_correls.Clear();

                List<double> avg = new List<double>(), avg_smoothed = new List<double>();

                for (int i = 0; i < fft_snaps.Count; i++)
                {
                    avg.Add(fft_snaps[i].Average());
                    avg_smoothed.Add(fft_smoothed_snaps[i].Average());
                }

                for (int i = 0; i < fft_snaps.Count; i++)
                    for (int j = 0; j < i/2; j++)
                    {
                        if (i != j)
                            snap_correls.Add(MC_Correl(fft_snaps[i], fft_snaps[j], avg[i], avg[j]));
                    }

                for (int i = 0; i < fft_smoothed_snaps.Count; i++)
                    for (int j = 0; j < i/2; j++)
                    {
                        if (i != j)
                            snap_smoothed_correls.Add(MC_Correl(fft_smoothed_snaps[i], fft_smoothed_snaps[j], avg_smoothed[i], avg_smoothed[j]));
                    }
            }

            public List<double> MC_Log10_Vec(List<double> vector)
            {
                var ans = new List<double>();
                double min = vector.Min();

                vector.ForEach(t => ans.Add(Math.Log10(t-0.9*min)));

                return ans;
            }

            public double MC_Log10_Energy(List<double> vector)
            {
                double ans = 0;

                var int_vec = MC_Log10_Vec(vector);

                double min_v = int_vec.Min(),
                    max_v = int_vec.Max();

                var sumsq = int_vec.Sum(t => Math.Pow((t - min_v) / (max_v - min_v), 2));

                ans = Math.Log10(Math.Sqrt(sumsq));

                return ans;
            }

            public double MC_Correl(List<double> vec1, List<double> vec2, double avg1, double avg2)
            {
                if (vec1.Count != vec2.Count)
                    return 0;

                double s = 0, divisor1 = 0, divisor2 = 0;
                //double vec1avg = vec1.Average(), vec2avg = vec2.Average();

                for (int i = 0; i < vec1.Count; i++)
                {
                    double diff1 = vec1[i] - avg1;
                    double diff2 = vec2[i] - avg2;
                    s += (diff1) * (diff2);
                    divisor1 += (diff1) * (diff1);
                    divisor2 += (diff2) * (diff2);
                }

                return s / Math.Sqrt(divisor1 * divisor2);
            }

            public List<double> Smoothen(List<double> vec, int smooth_size)
            {
                List<double> ans = new List<double>();

                double v = 0;

                for (int i = 0; i < vec.Count; i++)
                {
                    int first = Math.Max(i - (int)(smooth_size/2), 0);
                    int last  = Math.Min(i + (int)(smooth_size/2), vec.Count);
                    v = 0;
                    for (int j = first; j < last; j++)
                    {
                        v += vec[j];
                    }
                    ans.Add(v / (last - first));
                }

                return ans;
            }

            public double StDev(List<double> vec)
            {
                double avg = vec.Average();
                return Math.Sqrt(vec.Average(t => Math.Pow(t - avg, 2)));
            }

            public List<double> Normalize(List<double> vec)
            {
                var ans = new List<double>();
                double mean = vec.Average();
                double stdev = Math.Sqrt(vec.Average(t => Math.Pow(t - mean, 2)));
                foreach (var t in vec)
                    ans.Add((t - mean)/stdev);
                return ans;
            }
            public double[] Normalize(short[] vec, int length)
            {
                var ans = new double[length];
                double mean = vec.Average(t => (double)t);
                double stdev = Math.Sqrt(vec.Average(t => Math.Pow((double)t - mean, 2)));
                for (int i = 0; i < length; i++)
                    ans[i]  = (((double)vec[i] - mean) / stdev);
                return ans;
            }
        };

        public double Correl(List<double> vec1, List<double> vec2, double avg1, double avg2)
        {
            if (vec1.Count != vec2.Count)
                return 0;

            double s = 0, divisor1 = 0, divisor2 = 0;
            double vec1avg = vec1.Average(), vec2avg = vec2.Average();

            for (int i = 0; i < vec1.Count; i++)
            {
                double diff1 = vec1[i] - vec1avg;
                double diff2 = vec2[i] - vec2avg;
                s += (diff1) * (diff2);
                divisor1 += (diff1) * (diff1);
                divisor2 += (diff2) * (diff2);
            }

            return s / Math.Sqrt(divisor1 * divisor2);
        }

        public List<double> Normalize(List<double> vec)
        {
            var ans = new List<double>();

            double min = vec.Min(),
                max = vec.Max();

            foreach (var t in vec)
                ans.Add(t - min);

            return ans;
        }

        /*public List<double> MakeHistogram(_song_profile sp1, _song_profile sp2, double step)
        {
            var ans = new List<double>();
            var interm = new List<double>();

            List<double> avg = new List<double>(), avg_smoothed = new List<double>();
            for (int i = 0; i < sp1.fft_smoothed_snaps.Count; i++)
            {
                avg_smoothed.Add(sp1.fft_smoothed_snaps[i].Average());
            }

            foreach (var i in sp1.fft_smoothed_snaps)
                foreach (var j in sp2.fft_smoothed_snaps)
                    if (i.Count != j.Count)
                        return ans;
                    else
                        interm.Add(Correl(i, j));

            for (double k = 0; k <= 1; k += step)
                ans.Add((double)interm.Count(t => (t > k-step)&&(t <= k)) / (double)interm.Count);

            return ans;
        }*/

        public double HistogramConv(_song_profile sp1, _song_profile sp2, double step)
        {
            var ans = new List<double>();
            var interm = new List<double>();

            List<double> avg1_smoothed = new List<double>(), avg2_smoothed = new List<double>();
            for (int i = 0; i < sp1.fft_smoothed_snaps.Count; i++)
            {
                avg1_smoothed.Add(sp1.fft_smoothed_snaps[i].Average());
                avg2_smoothed.Add(sp2.fft_smoothed_snaps[i].Average());
            }

            for (int i = 0; i < sp1.fft_smoothed_snaps.Count; i++)//in sp1.fft_smoothed_snaps)
                for (int j = 0; j < sp2.fft_smoothed_snaps.Count; j++) //foreach (var j in sp2.fft_smoothed_snaps)
                    interm.Add(Correl(sp1.fft_smoothed_snaps[i], sp2.fft_smoothed_snaps[j], avg1_smoothed[i], avg2_smoothed[j]));

            for (double k = -1; k <= 1; k += step)
                ans.Add((double)interm.Count(t => (t > k-step)&&(t <= k)) / (double)interm.Count);

            double s = 0;
            for (int i = 0; i < ans.Count; i++)
                s += ans[i] * ((double)(i) - 1/step);

            return s*step;
        }

        public double StDev(List<double> vec)
        {
            double mean = vec.Average();
            return Math.Sqrt(vec.Average(t => Math.Pow(t - mean, 2)));
        }

        public double Skewness(List<double> vec)
        {
            double stdev = StDev(vec);
            double mean = vec.Average();
            return vec.Average(t => (Math.Pow((t - mean) / stdev, 3)));
        }

        public double Kurtosis(List<double> vec)
        {
            double stdev = StDev(vec);
            double mean = vec.Average();
            return vec.Average(t => (Math.Pow((t - mean) / stdev, 4)));
        }

        public double Median(List<double> vec)
        {
            var tmp = vec.OrderBy(t => t).ToList();
            if (tmp.Count % 2 == 0)
                return tmp[(int)(tmp.Count / 2)];
            else
                return tmp[(int)((tmp.Count - 1) / 2) + 1];
        }

        public int MedianVec(List<List<double>> vvec, string method)
        {
            var slice = new List<double>();

            for (int i = 0; i < vvec.Count(); i++)
            {
                switch (method)
                {
                    case "mean": 
                        slice.Add(vvec[i].Average());
                        break;
                    case "stdev":
                        slice.Add(StDev(vvec[i]));
                        break;
                    case "median":
                        slice.Add(Median(vvec[i]));
                        break;
                    default:
                        return -1;
                }
            }

            var v = Median(slice);
            
            switch (method)
            {
                case "mean":
                    return vvec.FindIndex(t => t.Average() == v);
                case "stdev":
                    return vvec.FindIndex(t => StDev(t) == v);
                case "median":
                    return vvec.FindIndex(t => Median(t) == v);
                default:
                    return -1;
            }
        }

        public double VecDiff(List<double> vec1, List<double> vec2)
        {
            double ans = 0;
            for (int i = 0; i < vec1.Count; i++)
                ans += Math.Pow(vec1[i] - vec2[i], 2);

            return ans;
        }

        public List<string> MakeFilesList(string startpath)
        {
            string[] files = Directory.GetFiles(startpath, "*.mp3", SearchOption.AllDirectories);

            return files.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var itm = new _song_profile("", "");
            itm.MakeSnaps((int)nUD2.Value, (int)nUD.Value, @"mp3\\diskord.mp3", (int)nUD3.Value);
            itm.CalcInternalCorrels();

            var itm2 = new _song_profile("", "");
            itm2.MakeSnaps((int)nUD2.Value, (int)nUD.Value, @"mp3\\diskord2.mp3", (int)nUD3.Value);
            itm2.CalcInternalCorrels();

            itm.snap_log10_energy = Normalize(itm.snap_log10_energy);
            itm2.snap_log10_energy = Normalize(itm2.snap_log10_energy); 

            listBox1.Items.Add("convoluted histogram value = " + HistogramConv(itm, itm2, 0.001)); 
        }

        public string Appdx(long i, long max_i)
        {
            string ans = "";
            long mi = (long)Math.Pow(10, Math.Floor(Math.Log10(max_i)));
            int a = (int)Math.Log10(max_i);
            int b = (i == 0 ? 0 : (int)Math.Log10(i));
            for (long j = a; j > b; j--)
                ans += "0";

            return ans + i.ToString();
        }

        public Dictionary<string, double> CalcAllStats(_song_profile itm)
        {
            var ans = new Dictionary<string, double>();

            //ans.Add("a_mean_ASC", itm.snap_correls.Average());
            //ans.Add("a_stdev_ASC", StDev(itm.snap_correls));
            //ans.Add("a_skewn_ASC", Skewness(itm.snap_correls));
            //ans.Add("a_kurto_ASC", Kurtosis(itm.snap_correls));
            //ans.Add("a_median_ASC", Median(itm.snap_correls));

            //ans.Add("mean_ASSC", itm.snap_smoothed_correls.Average());
            //ans.Add("stdev_ASSC", StDev(itm.snap_smoothed_correls));
            //ans.Add("skewn_ASSC", Skewness(itm.snap_smoothed_correls));
            //ans.Add("kurto_ASSC", Kurtosis(itm.snap_smoothed_correls));
            //ans.Add("median_ASSC", Median(itm.snap_smoothed_correls));
            
            //ans.Add("a_mean_ED", itm.snap_log10_energy.Average());
            //ans.Add("a_stdev_ED", StDev(itm.snap_log10_energy));
            //ans.Add("a_skewn_ED", Skewness(itm.snap_log10_energy));
            //ans.Add("a_kurto_ED", Kurtosis(itm.snap_log10_energy));
            //ans.Add("a_median_ED", Median(itm.snap_log10_energy));

            if (itm.fft_downscaled_snaps[0].Count > 5)
            {
                for (int i = 1; i < itm.fft_downscaled_snaps[0].Count / 2; i++)
                {
                    string a = Appdx(i, itm.fft_downscaled_snaps[0].Count);
                    var aa = new List<double>();
                    for (int j = 0; j < itm.fft_downscaled_snaps.Count; j++)
                    {
                        aa.Add(itm.fft_downscaled_snaps[j][i]);
                    }
                    ans.Add("b_mean_FFT1_" + a, aa.Average());
                    ans.Add("b_stdev_FFT1_" + a, StDev(aa));
                    ans.Add("b_skewn_FFT1_" + a, Skewness(aa));
                    ans.Add("b_kurto_FFT1_" + a, Kurtosis(aa));
                    ans.Add("b_median_FFT1_" + a, Median(aa));
                }

                /*
                for (int i = 0; i < itm.fft2_downscaled_snaps[0].Count / 2; i++)
                {
                    double v = 0;
                    string a = Appdx(i, itm.fft2_downscaled_snaps[0].Count);
                    for (int j = 0; j < itm.fft2_downscaled_snaps.Count; j++)
                        v += itm.fft2_downscaled_snaps[j][i];
                    ans.Add("mean_FFT2_" + a, v / itm.fft2_downscaled_snaps.Count);
                }
                */
            }

            return ans;
        }

        public void DBPostProcess(string dbname)
        {
            ExecuteCommandSync("sqlite3.exe < postprocess.sql");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to (re)create the database?", "Question", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            listBox1.Items.Clear();

            var fll = MakeFilesList(@textBox1.Text);
            var fl = fll.OrderBy(t => Path.GetFileName(t).Length.ToString()).ToList();

            listBox1.Items.Add("Found files: " + fl.Count);
            var db = new SQLiteConnection();
            var cmd = db.CreateCommand();

            try
            {
                db.ConnectionString = "Data Source=test.db;";
                db.Open();
                //cmd.CommandText = "DROP TABLE IF EXISTS MAIN;"; cmd.ExecuteNonQuery();
                //cmd.CommandText = "DROP TABLE IF EXISTS STATS;"; cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE MAIN (id int, name string, path string);"; cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE STATS (id int, statname string, statparam1 int, statparam2 int, statvalue float);"; cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Something has gone wrong with the database");
            }
            SQLiteParameter myparam1 = new SQLiteParameter();
            SQLiteParameter myparam2 = new SQLiteParameter();
            SQLiteParameter myparam3 = new SQLiteParameter();

            SQLiteParameter myparam2_1 = new SQLiteParameter();
            SQLiteParameter myparam2_2 = new SQLiteParameter();
            SQLiteParameter myparam2_3 = new SQLiteParameter();
            SQLiteParameter myparam2_4 = new SQLiteParameter();
            SQLiteParameter myparam2_5 = new SQLiteParameter();

            List<_song_profile> splist = new List<_song_profile>();
            
            int s_count = 0;

            PB1.Maximum = fl.Count;
            PB1.Minimum = 0;

            
            foreach (var f in fl)
            {
                //var transaction = db.BeginTransaction();
                try
                {
                    if (s_count % 50 == 0)
                    {
                        listBox1.Items.Clear();
                        listBox1.Items.Add("Items done: " + s_count + " of " + fl.Count);
                    }

                    var itm = new _song_profile(Path.GetFileName(f), f);
                    if (!itm.MakeSnaps((int)nUD2.Value, (int)nUD.Value, f, (int)nUD3.Value))
                    {
                        listBox1.Items.Add("![" + s_count + "]! Cannot make snapshots for " + itm.path);
                        s_count++;
                        continue;
                    }
                    //itm.CalcInternalCorrels();

                    itm.MakeDownscaledSnaps((int)nUD4.Value);
                    //itm.MakeDownscaledSnaps2((int)nUD4.Value);

                    var d = CalcAllStats(itm);

                    listBox1.Items.Add("[" + s_count + "] " + Path.GetFileName(itm.path));

                    cmd.CommandText = "BEGIN TRANSACTION;";
                    cmd.ExecuteNonQuery();

                    foreach (var di in d)
                    {

                        cmd.CommandText = "INSERT INTO STATS VALUES (@id, @statname, @statparam1, @statparam2, @statvalue);";
                        myparam2_1.ParameterName = "@id";
                        myparam2_2.ParameterName = "@statname";
                        myparam2_3.ParameterName = "@statparam1";
                        myparam2_4.ParameterName = "@statparam2";
                        myparam2_5.ParameterName = "@statvalue";

                        myparam2_1.Value = s_count;
                        myparam2_2.Value = di.Key;
                        myparam2_3.Value = 0;
                        myparam2_4.Value = 0;
                        myparam2_5.Value = di.Value;

                        cmd.Parameters.Add(myparam2_1); cmd.Parameters.Add(myparam2_2); cmd.Parameters.Add(myparam2_3);
                        cmd.Parameters.Add(myparam2_4); cmd.Parameters.Add(myparam2_5);
                        cmd.ExecuteNonQuery();
                    }

                    //splist.Add(itm);
                    cmd.CommandText = "INSERT INTO MAIN VALUES (@id, @name, @path);";
                    myparam1.ParameterName = "@id";
                    myparam2.ParameterName = "@name";
                    myparam3.ParameterName = "@path";

                    myparam1.Value = s_count;
                    myparam2.Value = itm.name;
                    myparam3.Value = itm.path;

                    cmd.Parameters.Add(myparam1);
                    cmd.Parameters.Add(myparam2);
                    cmd.Parameters.Add(myparam3);
                    cmd.ExecuteNonQuery();

                    PB1.Value = s_count;
                    Application.DoEvents();

                    //transaction.Commit();
                    cmd.CommandText = "COMMIT;";
                    cmd.ExecuteNonQuery();
                    s_count++;
                }
                catch
                {
                    continue;
                }
            }
            
            db.Close();

            DBPostProcess("test.db");
            /*
            var dct = new Dictionary<string, double>();

            for (int i = 0; i < splist.Count; i++)
            {
                dct.Add(splist[i].path, VecDiff(splist[0].scalar_stats.Values.ToList(), splist[i].scalar_stats.Values.ToList()));
            }

            dct.OrderBy(t => t.Value);

            dct.ToList().OrderBy(t => t.Value).ToList().ForEach(t => listBox1.Items.Add(t.Key + " ---> [" + t.Value + "]"));
            */

            /*************************************************************************
            k-means++ clusterization
            INPUT PARAMETERS:
                XY          -   dataset, array [0..NPoints-1,0..NVars-1].
                NPoints     -   dataset size, NPoints>=K
                NVars       -   number of variables, NVars>=1
                K           -   desired number of clusters, K>=1
                Restarts    -   number of restarts, Restarts>=1

            OUTPUT PARAMETERS:
                Info        -   return code:
                    * -3, if task is degenerate (number of distinct points is
                          less than K)
                    * -1, if incorrect NPoints/NFeatures/K/Restarts was passed
                    *  1, if subroutine finished successfully
                C           -   array[0..NVars-1,0..K-1].matrix whose columns store
                    cluster's centers
                XYC         -   array[NPoints], which contains cluster indexes
            *************************************************************************/
            /*
            int NPoints = splist.Count;
            int NVars = splist[0].scalar_stats.Count;
            int K = (int)Math.Sqrt(NPoints);
            int Restarts = 5;
            int Info = 0;
            
            var C = new double[NVars, K];
            var XYC = new int[NPoints];
            var XY = new double[NPoints, NVars];

            var _XY = splist[0].scalar_stats.Values.ToArray();
            for (int i = 0; i < NPoints; i++)
                for (int j = 0; j < NVars; j++)
                    XY[i, j] = splist[i].scalar_stats.Values.ToArray()[j];

            alglib.kmeansgenerate(
                XY,
                NPoints,
                NVars,
                K,
                Restarts,
                out Info,
                out C,
                out XYC);

            Info++;
            
            Application.DoEvents();

            for (int i = 0; i < splist.Count; i++)
            {
                listBox1.Items.Add(Path.GetFileName(splist[i].path) + " -> cluster # " + XYC[i]);
            }
             */

            /*foreach (var itm in splist)
            {
                var s1 = new List<double>();
                var s2 = new List<double>();
                var s3 = new List<double>(); 

                foreach (var itm2 in splist)
                {
                    /*listBox1.Items.Add(Path.GetFileName(itm.path) + " vs " + Path.GetFileName(itm2.path) +
                        "cross_energy_correl = " + Correl(itm.snap_log10_energy, itm2.snap_log10_energy, itm.snap_log10_energy.Average(), itm2.snap_log10_energy.Average()) + " " +
                        "cross_energy_diff = " + VecDiff(itm.snap_log10_energy, itm2.snap_log10_energy) + " " +
                        "convoluted histogram value = " + HistogramConv(itm, itm2, 0.001)
                        );*/
                    //s1.Add(Correl(itm.snap_log10_energy, itm2.snap_log10_energy, itm.snap_log10_energy.Average(), itm2.snap_log10_energy.Average()));
                    //s2.Add(1 / Math.Log10(VecDiff(itm.snap_log10_energy, itm2.snap_log10_energy)));
                    //s3.Add(HistogramConv(itm, itm2, 0.001));
                    /*s1.Add(0);
                    s2.Add(0);
                    s3.Add(0);
                }

                sp_CED.Add(s1);
                sp_CEC.Add(s2);
                sp_CHV.Add(s3);
            }*/

            /*List<double> likelihood = new List<double>();

            for (int i = 0; i < splist.Count; i++)
            {
                double lh = 0;
                //listBox1.Items.Add(Path.GetFileName(splist[i].path) + ": " + (int)(100*sp_ASC[i]) + " " + (int)(100*sp_ASSC[i]) + " " + (int)(10*sp_ED[i]));
                for (int j = 0; j < splist.Count; j++)
                {
                    lh = 
                        sp_ASC[i] * sp_ASC[j] +
                        sp_ASSC[i] * sp_ASSC[j] +
                        sp_ED[i] * sp_ED[j] +
                        sp_CED[i][j] + sp_CEC[i][j] + sp_CHV[i][j]
                        ;
                    likelihood.Add(lh);
                    listBox1.Items.Add((int)(100*lh) + " : " + Path.GetFileName(splist[i].path) + " " + Path.GetFileName(splist[j].path));
                }
                    //listBox1.Items.Add("----->" + (int)(100*sp_CED[i][j]) + " " + (int)(100*sp_CEC[i][j]) + " " + (int)(100*sp_CHV[i][j]) + "; " + Path.GetFileName(splist[j].path));
                
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var db = new SQLiteConnection();
            db.ConnectionString = "Data Source=test.db;";
            db.Open();

            var cmd = db.CreateCommand();
            cmd.CommandText = "CREATE TABLE A (id int, name string, path string, val01 float);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO A VALUES (0, 'asf', 'dfsdfsd', 543);";
            cmd.ExecuteNonQuery();

            db.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (fbrDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBox1.Text = fbrDlg.SelectedPath;
        }

        private void fbrDlg_HelpRequest(object sender, EventArgs e)
        {

        }

        private void nUD2_ValueChanged(object sender, EventArgs e)
        {
            lbl_sec_snap.Text = ((float)((int)(100 * nUD2.Value / 44100)) / 100).ToString();
            lbl_sec_tot.Text = ((float)((int)(100 * nUD.Value * nUD2.Value / 44100)) / 100).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nUD2_ValueChanged(sender, e);

            //OpenSnapDB(tbDBName.Text);
        }

        private void nUD_ValueChanged(object sender, EventArgs e)
        {
            nUD2_ValueChanged(sender, e);
        }

        public void OpenSnapDB(string dbpath, string searchfilter, bool openwhole)
        {
            string sf;

            if (!openwhole)
            {
                if (searchfilter.Length > 0)
                    sf = " where path like '%" + searchfilter.Replace(";", "%").Replace(" ","%") + "%'";
                else sf = "";
            }
            else
                sf = " limit 100";

            var db = new SQLiteConnection();
            db.ConnectionString = "Data Source=" + dbpath + ";";
            db.Open();

            var cmd = db.CreateCommand();
            cmd.CommandText = "select * from main" + sf;
            var data = cmd.ExecuteReader();

            dGV.Columns.Clear();
            dGV_tgt.Columns.Clear();
            dGV_pls.Columns.Clear();

            //dGV_pls.Columns.Add("dgp_dist", "dist");

            foreach (var c in data.GetValues())
            {
                dGV.Columns.Add("dg_" + (string)c, (string)c);
                dGV_tgt.Columns.Add("dgt_" + (string)c, (string)c);
                dGV_pls.Columns.Add("dgp_" + (string)c, (string)c);

                if ((string)c == "path")
                {
                    dGV.Columns["dg_path"].Width = 500;
                    dGV_tgt.Columns["dgt_path"].Width = 500;
                    dGV_pls.Columns["dgp_path"].Width = 500;
                }
            }

            while (data.HasRows)
            {
                data.Read();

                List<string> r = new List<string>();

                for (int i = 0; i < data.FieldCount; i++)
                    r.Add(data[i].ToString());

                dGV.Rows.Add(r.ToArray());
            }

            /*
            var cmd2 = db.CreateCommand();
            cmd2.CommandText = "select distinct statname from stats order by 1";// limit 500";
            data = cmd2.ExecuteReader();
            clbFeatures.Items.Clear();

            while (data.HasRows)
            {
                data.Read();
                clbFeatures.Items.Add(data["statname"].ToString());
            }
            */
            db.Close();
        }

        private void dGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var c = new DataGridViewCellCollection(dGV.Rows[e.RowIndex]);
            c = dGV.Rows[e.RowIndex].Cells;

            var cs = new List<string>();

            for (int i = 0; i < c.Count; i++ )
                cs.Add(c[i].Value.ToString());
            
            dGV_tgt.Rows.Add(cs.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = true;
            Application.DoEvents();

            dGV_pls.Rows.Clear();

            if (dGV_tgt.RowCount < 1)
            {
                MessageBox.Show("No target tracks selected!");
                return;
            }

            var idList = new List<string>();

            for (int i = 0; i < dGV_tgt.RowCount; i++)
            {
                idList.Add(dGV_tgt.Rows[i].Cells["dgt_id"].Value.ToString());
            }

            //MessageBox.Show(String.Join(", ", idList.ToArray()));

            var db = new SQLiteConnection();
            db.ConnectionString = "Data Source=" + tbDBName.Text + ";";
            db.Open();

            var cmd = db.CreateCommand();

            string maxthr = (nUD_MaxThr.Value).ToString();
            string tgtid = String.Join(", ", idList.ToArray());
            string s = "select * from main ";

            s += "where id in (select id from (";// + String.Join(", ", idList.ToArray()) + ");";
            s += "select b.id, sum(((a.statvalue - b.statvalue)*(a.statvalue - b.statvalue))/(c1.value*c1.value)) as distance, ";
            s += "10000*max((a.statvalue - b.statvalue)*(a.statvalue - b.statvalue)/(c2.value*c2.value)) as maxdiff, ";
            s += "10000*avg((a.statvalue - b.statvalue)*(a.statvalue - b.statvalue)/(c2.value*c2.value)) as meandiff ";
            s += "from stats a, stats b, feature c1, ";
            s += "feature c2 ";
            s += "where ";
            s += "a.id in (" + tgtid + ") and ";
            s += "b.id not in (" + tgtid + ", 631, 1919, 2492, 2857, 7364, 8743, 19515, 21878, 23643, 26271, 26403, 28917, 13815, 15466, 14997, 26212) and ";
            s += "a.statname = c1.statname and c1.feature = 'mean' and ";
            s += "a.statname = c2.statname and ";
            s += "c2.feature = 'max_min' and ";
            s += "a.statname = b.statname and ";
            s += "c1.statname = c2.statname and ";
            s += "a.statvalue <= b.statvalue + " + maxthr + "*c2.value/100 and a.statvalue >= b.statvalue - " + maxthr + "*c2.value/100 and ";
            s += "a.statname in ( ";

            for (int k = 1; k <= 31; k += 2)
            {
                if (cbOverStats.Checked)
                    foreach (var si in clbStatnames.CheckedItems)
                    {
                        var sii = (string)si;
                        if (sii == "Mean")
                            s += "'b_mean_FFT1_" + Appdx(k, 31) + "', ";
                        if (sii == "Median")
                            s += "'b_median_FFT1_" + Appdx(k, 31) + "', ";
                        if (sii == "St.dev.")
                            s += "'b_stdev_FFT1_" + Appdx(k, 31) + "', ";
                        if (sii == "Skewness")
                            s += "'b_skewn_FFT1_" + Appdx(k, 31) + "', ";
                        if (sii == "Kurtosis")
                            s += "'b_kurto_FFT1_" + Appdx(k, 31) + "', ";
                    }
                else
                {
                    s += "'b_median_FFT1_" + Appdx(k, 31) + "', ";
                    s += "'b_stdev_FFT1_" + Appdx(k, 31) + "', ";
                    s += "'b_skewn_FFT1_" + Appdx(k, 31) + "', ";
                    s += "'b_kurto_FFT1_" + Appdx(k, 31) + "', ";
                }
                //if (k < 31) s += ", ";
            }
            s += "'a' ";            
            s += ") ";
            s += "group by b.id ";
            s += "having maxdiff <= " + ((int)(nUD_MaxMax.Value*nUD_MaxMax.Value)).ToString() + " ";
            s += "and ";
            s += "meandiff <= " + ((int)(nUD_MaxMean.Value * nUD_MaxMean.Value)).ToString() + " ";
            if (cbOrderBy.Checked)
                s += "order by distance ";
            s += "limit " + ((int)nUD_tracks.Value).ToString();
            s += ") );";

            if (MessageBox.Show(s, "Do you wish to proceed", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
            {
                lblMsg.Visible = false;
                return;
            }

            cmd.CommandText = s;

            var data = cmd.ExecuteReader();

            while (data.HasRows)
            {
                data.Read();
                List<string> r = new List<string>();
                for (int i = 0; i < data.FieldCount; i++)
                    r.Add(data[i].ToString());
                dGV_pls.Rows.Add(r.ToArray());
            }

            lblMsg.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = true;
            Application.DoEvents();
            OpenSnapDB(tbDBName.Text, "", false);
            lblMsg.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dGV_tgt.Rows.Clear();
        }

        private void dGV_tgt_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string filename = dGV_tgt.Rows[e.RowIndex].Cells["dgt_path"].Value.ToString();
            ExecuteCommandAsync("explorer \"" + filename + "\"");
        }


        public void ExecuteCommandSync(object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                Console.WriteLine(result);
            }
            catch (Exception objException)
            {
                // Log the exception
            }
        }
        public void ExecuteCommandAsync(string command)
        {
            try
            {
                //Asynchronously start the Thread to process the Execute command request.
                Thread objThread = new Thread(new ParameterizedThreadStart(ExecuteCommandSync));
                //Make the thread as background thread.
                objThread.IsBackground = true;
                //Set the Priority of the thread.
                objThread.Priority = ThreadPriority.AboveNormal;
                //Start the thread.
                objThread.Start(command);
            }
            catch (ThreadStartException objException)
            {
                // Log the exception
            }
            catch (ThreadAbortException objException)
            {
                // Log the exception
            }
            catch (Exception objException)
            {
                // Log the exception
            }
        }

        private void dGV_pls_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string filename = dGV_pls.Rows[e.RowIndex].Cells["dgp_path"].Value.ToString();
            ExecuteCommandAsync("explorer \"" + filename + "\"");
        }

        private void cbEnableFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableFilter.Checked)
                OpenSnapDB(tbDBName.Text, tbFilterTracks.Text, false);
            else
                OpenSnapDB(tbDBName.Text, "", false);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cbEnableFilter_CheckedChanged(sender, e);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            List<string> playlist = new List<string>();
            var s = new StreamWriter(@"tmp_playlist.m3u", false);

            for (int i = 0; i < dGV_pls.Rows.Count; i++)
            {
                playlist.Add(dGV_pls.Rows[i].Cells["dgp_path"].Value.ToString());
            }

            foreach (var p in playlist)
            {
                s.WriteLine(p);
            }

            s.Close();

            ExecuteCommandAsync("explorer \"tmp_playlist.m3u\"");
        }

        private void cbOverStats_CheckedChanged(object sender, EventArgs e)
        {
            clbStatnames.Enabled = cbOverStats.Checked;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            OpenSnapDB(tbDBName.Text, "", true);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ExecuteCommandAsync("explorer \"tmp_playlist.m3u\"");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DBPostProcess("");
        }
    }
}
