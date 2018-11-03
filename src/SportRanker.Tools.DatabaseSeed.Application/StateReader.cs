using System.Collections.Generic;
using System.IO;
using System.Linq;
using SportRanker.Tools.DatabaseSeed.Contracts;

namespace SportRanker.Tools.DatabaseSeed.Application
{
    public static class StateReader
    {
        public static ICollection<State> ParseCsv(string csvPath)
        {
            var states = new List<State>();

            var parsedStates = File
                .ReadAllLines(csvPath)
                .Skip(1)
                .Select(l => new StateCsv(l))
                .ToList();

            foreach (var parsedState in parsedStates)
            {
                if (parsedState.ToState().TrySome(out var state))
                    states.Add(state);
            }

            return states;
        }
    }
}
