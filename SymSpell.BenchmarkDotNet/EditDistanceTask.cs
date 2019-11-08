using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace SymSpellBenchmarkDotNet
{
    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    [MemoryDiagnoser, GcServer(true)]
    [RankColumn]
    public class EditDistanceTask
    {
        private const string Text1Base = "whereis th elove hehad dated forImuch of thepast who couqdn'tread in sixthgrade and ins pired him whereis th elove hehad dated forImuch of thepast who couqdn'tread in sixthgrade and ins pired him whereis th elove hehad dated forImuch of thepast who couqdn'tread in sixthgrade and ins pired him whereis th elove hehad dated forImuch of thepast who couqdn'tread in sixthgrade and ins pired him whereis th elove hehad dated forImuch of thepast who couqdn'tread in sixthgrade and ins pired him ";
        private const string Text2Base = "where is the love he had dated for much of the past who couldn't read in sixth grade and inspired him where is the love he had dated for much of the past who couldn't read in sixth grade and inspired him where is the love he had dated for much of the past who couldn't read in sixth grade and inspired him where is the love he had dated for much of the past who couldn't read in sixth grade and inspired him where is the love he had dated for much of the past who couldn't read in sixth grade and inspired him ";

        private string _text1;
        private string _text2;

        [IterationSetup]
        public void IterationSetup()
        {
            _text1 = $"{Text1Base} {Guid.NewGuid()}";
            _text2 = $"{Text2Base} {Guid.NewGuid()}";
        }

        [Benchmark]
        public int DamerauOSA_SpanFeatureOff() => Run(new EditDistance(EditDistance.DistanceAlgorithm.DamerauOSA, useSpanFeature: false));

        [Benchmark]
        public int DamerauOSA_SpanFeatureOn() => Run(new EditDistance(EditDistance.DistanceAlgorithm.DamerauOSA, useSpanFeature: true));

        [Benchmark]
        public int Levenshtein_SpanFeatureOff() => Run(new EditDistance(EditDistance.DistanceAlgorithm.Levenshtein, useSpanFeature: false));

        private int Run(EditDistance editDistance)
        {
            return editDistance.Compare(_text1, _text2, 100);
        }
    }
}
