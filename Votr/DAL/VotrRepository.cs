using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Votr.Models;

namespace Votr.DAL
{
    public class VotrRepository
    {
        public VotrContext context { get; set; }

        //this constructor will initialize if no argument is passed in.
        public VotrRepository()
        {
            // We need an instance of a Context
            context = new VotrContext();
        }

        //this provides a way for us to pass a context into the votr repository so that we don't have to rely on a database for testing. This constructor will initialize if we pass in an argument.
        public VotrRepository(VotrContext _context)
        {
            context = _context;
        }

        public int GetPollCount()
        {
            //return GetPolls().Count;
            // Another way
            return context.Polls.Count();
        }

        public List<Poll> GetPolls()
        {
            return context.Polls.ToList<Poll>();
        }

        public void AddPoll(string title, DateTime start_time, DateTime end_time)
        {
            throw new NotImplementedException();
        }
        // Create a Poll

        // Delete a Poll

        // Vote
    }
}