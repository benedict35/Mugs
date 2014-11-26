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

            var f = db.Workers.Where(x => x is HardWorker).ToList();
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

        protected void TakeMug(object sender, EventArgs e)
        {
            
        }

        protected void ReturnMug(object sender, EventArgs e)
        {

        }
    }
}