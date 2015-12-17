using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cis237Assignment6.Models;

namespace cis237Assignment6.Controllers
{
    [Authorize]
    public class BeverageController : Controller
    {
        private BeverageEntities db = new BeverageEntities();

        // GET: /Beverage/
        // Significantly updated/modified for filter functionality.
        public ActionResult Index()
        {
            // Variable to hold Data Set.
            DbSet<Beverage> BeveragesToSearch = db.Beverages;

            // Set up variables.
            string filterId = "";
            string filterName = "";
            string filterPack = "";
            string filterPrice = "";
            string filterActive = "";

            const int MIN_PRICE = 0;
            decimal aPrice = 0;

            #region Cast session to variables, if session is present and not empty.
            if (Session["id"] != null && ((string)Session["id"]).Trim() != "")
            {
                filterId = (string)Session["id"];
            }

            if (Session["name"] != null && ((string)Session["name"]).Trim() != "")
            {
                filterName = (string)Session["name"];
            }

            if (Session["pack"] != null && ((string)Session["pack"]).Trim() != "")
            {
                filterPack = (string)Session["pack"];
            }

            if (Session["price"] != null && ((string)Session["price"]).Trim() != "")
            {
                // TryCatch to make sure input is a number greater than 0.
                try
                {
                    string priceString = (string)Session["price"];
                    aPrice = Convert.ToInt32(priceString);
                    if (aPrice >= MIN_PRICE)
                    {
                        filterPrice = (string)Session["price"];
                    }
                }
                catch
                {

                }

            }

            if (Session["active"] != null && ((string)Session["active"]).Trim() != "")
            {
                filterActive = (string)Session["active"];
            }
            #endregion

            // Create actual filter for BeverageToSearch DataSet.

            IEnumerable<Beverage> filtered;

            if (filterActive.ToLower() == "true" || filterActive.ToLower() == "false")
            {
                bool activeBool = (filterActive.ToLower() == "true");

                filtered = BeveragesToSearch.Where(beverage => beverage.id.Contains(filterId) &&
                                                                beverage.name.Contains(filterName) &&
                                                                beverage.pack.Contains(filterPack) &&
                                                                beverage.price >= aPrice &&
                                                                beverage.active.Equals(activeBool));
            }
            else
            {
                filtered = BeveragesToSearch.Where(beverage => beverage.id.Contains(filterId) &&
                                                                beverage.name.Contains(filterName) &&
                                                                beverage.pack.Contains(filterPack) &&
                                                                beverage.price >= aPrice);
            }

            // Convert filtered DataSet to list.
            IEnumerable<Beverage> finalFiltered = filtered.ToList();

            // Add Session info to viewbag. Used to send to view to retain user's input.
            ViewBag.filterId = filterId;
            ViewBag.filterName = filterName;
            ViewBag.filterPack = filterPack;
            ViewBag.filterPrice = filterPrice;
            ViewBag.filterActive = filterActive;

            // Return 
            return View(finalFiltered);
        }

        // GET: /Beverage/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beverage beverage = db.Beverages.Find(id);
            if (beverage == null)
            {
                return HttpNotFound();
            }
            return View(beverage);
        }

        // GET: /Beverage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Beverage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,pack,price,active")] Beverage beverage)
        {
            if (ModelState.IsValid)
            {
                db.Beverages.Add(beverage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beverage);
        }

        // GET: /Beverage/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beverage beverage = db.Beverages.Find(id);
            if (beverage == null)
            {
                return HttpNotFound();
            }
            return View(beverage);
        }

        // POST: /Beverage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,pack,price,active")] Beverage beverage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beverage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beverage);
        }

        // GET: /Beverage/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beverage beverage = db.Beverages.Find(id);
            if (beverage == null)
            {
                return HttpNotFound();
            }
            return View(beverage);
        }

        // POST: /Beverage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Beverage beverage = db.Beverages.Find(id);
            db.Beverages.Remove(beverage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Action to use filter on view.
        [HttpPost, ActionName("Filter")]
        [ValidateAntiForgeryToken]
        public ActionResult Filter()
        {
            // Get data from form.
            string id = Request.Form.Get("id");
            string name = Request.Form.Get("name");
            string pack = Request.Form.Get("pack");
            string price = Request.Form.Get("price");
            string active = Request.Form.Get("active");

            // Store data in user's session.
            Session["id"] = id;
            Session["name"] = name;
            Session["pack"] = pack;
            Session["price"] = price;
            Session["active"] = active;

            // Redirect to index which does the work fo actually filtering within our get-data method (at the top of this class).
            return RedirectToAction("Index");
        }

    }
}
