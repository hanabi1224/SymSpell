using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace SymSpellBenchmarkDotNet
{
    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    [MemoryDiagnoser, GcServer(true)]
    [RankColumn]
    public class EditDistanceTask
    {
        [Benchmark]
        public int DamerauOSA_SpanFeatureOff() => Run(new EditDistance(EditDistance.DistanceAlgorithm.DamerauOSA, useSpanFeature: false));

        [Benchmark]
        public int DamerauOSA_SpanFeatureOn() => Run(new EditDistance(EditDistance.DistanceAlgorithm.DamerauOSA, useSpanFeature: true));

        [Benchmark]
        public int Levenshtein_SpanFeatureOff() => Run(new EditDistance(EditDistance.DistanceAlgorithm.Levenshtein, useSpanFeature: false));

        private int Run(EditDistance editDistance)
        {
            var text1 = "whereis th elove hehad dated forImuch of thepast who couqdn'tread in sixthgrade and ins pired him whereis th elove hehad dated forImuch of thepast who couqdn'tread in sixthgrade and ins pired him whereis th elove hehad dated forImuch of thepast who couqdn'tread in sixthgrade and ins pired him whereis th elove hehad dated forImuch of thepast who couqdn'tread in sixthgrade and ins pired him whereis th elove hehad dated forImuch of thepast who couqdn'tread in sixthgrade and ins pired him ";
            var text2 = "where is the love he had dated for much of the past who couldn't read in sixth grade and inspired him where is the love he had dated for much of the past who couldn't read in sixth grade and inspired him where is the love he had dated for much of the past who couldn't read in sixth grade and inspired him where is the love he had dated for much of the past who couldn't read in sixth grade and inspired him where is the love he had dated for much of the past who couldn't read in sixth grade and inspired him ";

            return editDistance.Compare(text1, text2, 10);
        }
    }
}
