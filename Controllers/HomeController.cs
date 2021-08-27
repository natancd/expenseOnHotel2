using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ExpenseOnHotel2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Hotel model)
        {
            string message = "";
            if (model.HotelAmenities == null)
                model.HotelAmenities = "-";
            if (model.HotelComplement == null)
                model.HotelComplement = "-";
            string input = ValidateInput(model.HotelName, model.HotelEvaluation.ToString(), model.HotelDescription, model.HotelAddress, model.HotelCEP.ToString(), model.HotelCity, model.HotelState, model.HotelAmenities);
            if (input == "")
            {                
                using (var context = new HotelDatabaseEntities())
                {
                    context.Hotel.Add(model);
                    context.SaveChanges();
                }
                message = "Registro criado";
                ViewBag.Message = message;
                return View();
            }
            else
            {
                ViewBag.Error = input;
                return View();
            }
            
        }
        [HttpGet] 
        public ActionResult Read(string searchStringName, string searchStringAmenities)
        {
            HotelDatabaseEntities db = new HotelDatabaseEntities();

            var hotel = from h in db.Hotel select h;

            if (searchStringName == "" && searchStringAmenities == "")
            using (var context = new HotelDatabaseEntities())
            {
                var data = context.Hotel.ToList();
                    ModelState.Clear();

                    return View(data);
            }
            
            if (!string.IsNullOrEmpty(searchStringName))
                hotel = hotel.Where(n => n.HotelName.Contains(searchStringName));

            if (!string.IsNullOrEmpty(searchStringAmenities))
                hotel = hotel.Where(n => n.HotelAmenities.Contains(searchStringAmenities));     

            return View(hotel);
        }

        public ActionResult Update(int hotelID)
        {
            using (var context = new HotelDatabaseEntities())
            {
                var data = context.Hotel.Where(x => x.HotelID == hotelID).SingleOrDefault();
                return View(data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int hotelID, Hotel model)
        {
            using (var context = new HotelDatabaseEntities())
            {
                var data = context.Hotel.FirstOrDefault(x => x.HotelID == hotelID);

                if (data != null)
                {
                    data.HotelID = model.HotelID;
                    data.HotelName = model.HotelName;
                    data.HotelEvaluation = model.HotelEvaluation;
                    data.HotelDescription = model.HotelDescription;
                    data.HotelAddress = model.HotelAddress;
                    data.HotelComplement = model.HotelComplement;
                    data.HotelCEP = model.HotelCEP;
                    data.HotelCity = model.HotelCity;
                    data.HotelState = model.HotelState;
                    data.HotelAmenities = model.HotelAmenities;
                    context.SaveChanges();

                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int hotelID)
        {
            using (var context = new HotelDatabaseEntities())
            {
                var data = context.Hotel.FirstOrDefault(x => x.HotelID == hotelID);
                if (data != null)
                {
                    context.Hotel.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }
        

        //public ViewResult Read(string searchString)
        //{
            
        //}

        private string ValidateInput(string hotelName, string hotelEvaluation, string hotelDescription, string hotelAddress, string hotelCEP, string hotelCity, string hotelState, string hotelComplement)
        {
            Regex regex = new Regex("^[0-9]+$");
            const int MINIMUM_LENGTH = 3;
            const int MAXIMUM_LENGTH = 300;
            const int MAXIMUM_LENGTH_COMPLEMENT = 50;

            if (hotelName == "" || hotelName == null|| hotelName.Length < MINIMUM_LENGTH)
            {
                return "O nome do Hotel não pode estar em branco e deve conter ao menos 3 caracteres";
            }
            if (hotelEvaluation == "" || hotelEvaluation == null)
            {
                return "A avaliação deve ser selecionada!";
            }
            if (hotelDescription == "" || hotelDescription == null || hotelDescription.Length < MINIMUM_LENGTH)
            {
                return "A descrição do Hotel não pode estar em branco e deve conter ao menos 3 caracteres";
            }
            if (hotelAddress == "" || hotelAddress == null || hotelAddress.Length < MINIMUM_LENGTH)
            {
                return "O endereço do Hotel não pode estar em branco e deve conter ao menos 3 caracteres";
            }
            if (hotelComplement != null && hotelComplement.Length > MAXIMUM_LENGTH_COMPLEMENT)
            {
                return "O campo Complemento não pode exceder 50 caracteres";
            }
            if (!regex.IsMatch(hotelCEP))
            {
                return "O CEP do Hotel deve conter somente números!";
            }
            if (hotelCEP == "" || hotelCEP == null || hotelCEP.Length != 8)
            {
                return "O CEP deve conter 8 caracteres numéricos apenas!";
            }
            if (hotelCity == "" || hotelCity == null || hotelDescription.Length < MINIMUM_LENGTH)
            {
                return "O campo Cidade não pode estar em branco e deve conter ao menos 3 caracteres";
            }
            if (hotelState == "" || hotelState == null || hotelState.Length < MINIMUM_LENGTH -1)
            {
                return "O campo Estado não pode estar em branco e deve conter ao menos 2 caracteres";
            }
            if (hotelComplement != null && hotelComplement.Length > MAXIMUM_LENGTH)
            {
                return "O campo Comodidades não pode exceder 300 caracteres";
            }

            return "";

        }
    }
}