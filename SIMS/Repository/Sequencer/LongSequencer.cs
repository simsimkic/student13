// File:    LongSequencer.cs
// Created: 23. maj 2020 16:21:53
// Purpose: Definition of Class LongSequencer

using System;

namespace SIMS.Repository.Sequencer
{
    public class LongSequencer : ISequencer<long>
    {
        private long nextID;

        public long GenerateID()
        {
            return ++nextID;
        }

        public void Initialize(long initID)
        {
            nextID = initID;
        }
    }
}