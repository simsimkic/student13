// File:    ComplexSequencer.cs
// Created: 23. maj 2020 16:21:53
// Purpose: Definition of Class ComplexSequencer

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Sequencer
{
    public class ComplexSequencer : ISequencer<UserID>
    {
        private UserID nextID;

        public UserID GenerateID() 
        {
            nextID = nextID.increment();
            return new UserID(nextID.ToString());
        }

        public void Initialize(UserID initID)
        {
            nextID = new UserID(initID.ToString());
        }
        
    }
}