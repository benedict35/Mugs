using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mugs.Models;

namespace Mugs
{
    public partial class _Default : Page
    {

        public ApplicationDbContext db = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            var numberOfMugsTakenByHardWorkers = db.Workers.Where(x => x is HardWorker).ToList().Sum(x => x.Mugs.Count);
            var numberOfMugsTakenByHappyWorkers = db.Workers.Where(x => x is HappyWorker).ToList().Sum(x => x.Mugs.Count);
            var numberOfMugsTakenByHopelessWorkers = db.Workers.Where(x => x is HopelessWorker).ToList().Sum(x => x.Mugs.Count);
            var totalMugs = db.Mugs.Count();
            var totalMugsTaken = numberOfMugsTakenByHappyWorkers + numberOfMugsTakenByHardWorkers +
                                 numberOfMugsTakenByHopelessWorkers;
            var totalMugsAvailable = totalMugs - totalMugsTaken;

            hard.Text = numberOfMugsTakenByHardWorkers.ToString();
            happy.Text = numberOfMugsTakenByHappyWorkers.ToString();
            hopeless.Text = numberOfMugsTakenByHopelessWorkers.ToString();

            taken.Text = totalMugsTaken.ToString();
            available.Text = totalMugsAvailable.ToString();

            if (totalMugs > 0 && totalMugsAvailable == 0)
            {
                return_message.Text = "All mugs are taken";
            }
            else if (totalMugs == 0)
            {
                return_message.Text = "No mugs to take or return";
            }

        }

        public void UpdateStats()
        {
            var numberOfMugsTakenByHardWorkers = db.Workers.Where(x => x is HardWorker).ToList().Sum(x => x.Mugs.Count);
            var numberOfMugsTakenByHappyWorkers = db.Workers.Where(x => x is HappyWorker).ToList().Sum(x => x.Mugs.Count);
            var numberOfMugsTakenByHopelessWorkers = db.Workers.Where(x => x is HopelessWorker).ToList().Sum(x => x.Mugs.Count);
            var totalMugs = db.Mugs.Count();
            var totalMugsTaken = numberOfMugsTakenByHappyWorkers + numberOfMugsTakenByHardWorkers +
                                 numberOfMugsTakenByHopelessWorkers;
            var totalMugsAvailable = totalMugs - totalMugsTaken;

            hard.Text = numberOfMugsTakenByHardWorkers.ToString();
            happy.Text = numberOfMugsTakenByHappyWorkers.ToString();
            hopeless.Text = numberOfMugsTakenByHopelessWorkers.ToString();

            taken.Text = totalMugsTaken.ToString();
            available.Text = totalMugsAvailable.ToString();
        }

        protected void TakeMug(object sender, EventArgs e)
        {
            var totalMugs = db.Mugs.Count();
            var mugsAvailable = db.Mugs.Where(x => x.MugStatus == MugStatus.Available).ToList();
            var numberOfMugsAvailable = mugsAvailable.Count;
            if (numberOfMugsAvailable > 0)
            {

                var mugToTake = mugsAvailable[GetRandomNumber(numberOfMugsAvailable)];
                var workers = db.Workers.ToList();
                var totalNumberOfWorkers = workers.Count;
                if (totalNumberOfWorkers > 0)
                {
                    var workerToTakeMug = workers[GetRandomNumber(totalNumberOfWorkers)];

                    mugToTake.MugStatus = MugStatus.InUse;
                    workerToTakeMug.Mugs.Add(mugToTake);
                    db.SaveChanges();
                    return_message.Text = GetWorkerType(workerToTakeMug)+" took mug";
                }
                else
                {
                    return_message.Text = "No workers to assign mugs to";
                }
            }
            else if (totalMugs > 0)
            {
                return_message.Text = "All mugs are taken";
            }
            else
            {
                return_message.Text = "No mugs to take or return";
            }
            UpdateStats();
            
        }

        protected void ReturnMug(object sender, EventArgs e)
        {
            var totalMugs = db.Mugs.Count();
            var mugsInUse = db.Mugs.Where(x => x.MugStatus == MugStatus.InUse).ToList();
            var numberOfMugsInUse = mugsInUse.Count;
            if (numberOfMugsInUse > 0)
            {
                var workersWithMugs = db.Workers.Where(x => x.Mugs.Count > 0).ToList();
                var totalNumberOfWorkersWithMugs = workersWithMugs.Count;
                if (totalNumberOfWorkersWithMugs > 0)
                {
                    var workerToReturnMug = workersWithMugs[GetRandomNumber(totalNumberOfWorkersWithMugs)];
                    var numberOfMugsWorkerIsUsing = workerToReturnMug.Mugs.Count;
                    var mugToReturn = workerToReturnMug.Mugs.ToList()[GetRandomNumber(numberOfMugsWorkerIsUsing)];
                    mugToReturn.MugStatus = MugStatus.Available;
                    workerToReturnMug.Mugs.Remove(mugToReturn);
                    db.SaveChanges();
                    return_message.Text = GetWorkerType(workerToReturnMug) + " returned mug";
                }
                else
                {
                    return_message.Text = "No workers to unassign mugs from";
                }
            }
            else if (totalMugs > 0)
            {
                return_message.Text = "All mugs are available";
            }
            else
            {
                return_message.Text = "No mugs to take or return";
            }
            UpdateStats();
        }

        private int GetRandomNumber(int maxValue)
        {
            var randomGenerator = new Random();
            return randomGenerator.Next(maxValue);
        }

        private string GetWorkerType(Worker worker)
        {
            if (worker is HappyWorker)
            {
                return "Happy Worker";
            }
            else if (worker is HardWorker)
            {
                return "Hard Worker";
            }
            else if (worker is HopelessWorker)
            {
                return "Hopeless Worker";
            }
            return "Unknown Worker";
        }
    }
}