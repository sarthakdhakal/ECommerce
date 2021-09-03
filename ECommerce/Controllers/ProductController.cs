
using System; 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{

    public class ProductController : Controller
    {
        ECommerceEntities db = new ECommerceEntities(); 
        int productId;
        public ActionResult Index()
        {
            // List<ProductViewModel> productList = db.Products.Select(x=> new ProductViewModel()
            // {
            //     ProductId = x.ProductId,
            //     ProductName = x.ProductName,
            //     ProductPrice = x.ProductPrice,
            //     ProductQuantity = x.ProductQuantity
            //     
            // }).ToList();
            //  // var img = ProductViewModel.Join()
            //  List<ProductImageViewModel> productImageViewModels =
            //      db.ProductImages.Select(x => new ProductImageViewModel()
            //      {
            //          ImagePath = x.ImagePath,
            //          ImageId = x.ImageId,
            //          ProductId = x.ProductId,
            //        
            //      }).ToList();
             // var displayViewModels = productList.Join(productImageViewModels,
             //     product => product.ProductId,
             //     productImage => productImage.ProductId,
             //     ((product, productImage) => new
             //     {
             //         ProductId = product.ProductId,
             //         ProductName = product.ProductName,
             //         ProductPrice = product.ProductPrice,
             //         ProductQuantity = product.ProductQuantity,
             //         ProductImage = productImage.ImagePath.FirstOrDefault(x=> product.ProductId==productImage.ProductId)
             //     })).ToList();
            DisplayViewModel model =new DisplayViewModel();
            model.DisplayViewModelsList = db.Products.Select(x => new DisplayViewModel() {
            ProductId=x.ProductId,
            ProductName=x.ProductName,
            }).Where(x=>x.ProductId==1004).ToList();
            foreach (var item in model.DisplayViewModelsList)
            {
                item.ImageViewModelsList = db.ProductImages.Where(x => x.ProductId == item.ProductId).Select(
                    y => new DisplayViewModel()
                    {
                ImageId=y.ImageId,
                ImagePath=y.ImagePath,
                
                }).ToList();

            }
                return View(model.DisplayViewModelsList);
        }

        public ActionResult AddProduct()
        {
            List<Category> categories = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(categories,"CategoryId","CategoryName");

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(FormCollection form, HttpPostedFileBase file)
        {
            if (form != null) {
                Product product = new Product();
                product.ProductName = form["ProductName"];
                product.ProductPrice = Convert.ToInt32(form["ProductPrice"]);
                product.ProductQuantity = Convert.ToInt32(form["ProductQuantity"]);
                db.Products.Add(product);
                db.SaveChanges();
                productId = product.ProductId;
            }
            
            string folderPath = Server.MapPath("~/UploadedImage/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (file != null )
            {
                if (file.ContentType == "image/jpeg" ||
                    file.ContentType == "image/jpg" ||
                    file.ContentType == "image/gif" ||
                    file.ContentType == "image/png")                {
                    var fileName = Path.GetFileName(file.FileName);
                    var userfolderpath = Path.Combine(Server.MapPath("~/UploadedImage/"), fileName);
                    var fullPath = Server.MapPath("~/UploadedImage/") +  file.FileName;
                    var savePath = "~UploadedImage/" + fileName;
                    
                    if (System.IO.File.Exists(fullPath))
                    {
                        ViewBag.ActionMessage = "Same File already Exists";
                    }
                    else    
                    {
                        file.SaveAs(userfolderpath);
                        ViewBag.ActionMessage = "File has been uploaded successfully";
                        ProductImage productImage = new ProductImage();
                        productImage.ImagePath = savePath;
                        productImage.ProductId = productId;
                        db.ProductImages.Add(productImage);
                        db.SaveChanges();
                    }
                }
                else
                {   
                    ViewBag.ActionMessage = "Please upload only imag (jpg,gif,png)";
                }
            }
            else
            {
                return View("AddProduct");
            }
            return RedirectToAction("Index");
            

        
        }

        public ActionResult DisplayProduct(int? ProductId)
        {
            
            if (ProductId>0)
            {
                List<ProductViewModel> productViewModels = db.Products.Where(x => x.ProductId == ProductId)
                    .Select(x => new ProductViewModel
                        {
                            ProductName = x.ProductName,
                            ProductPrice = x.ProductPrice,
                            ProductQuantity = x.ProductQuantity,
                            CategoryName = x.Category.CategoryName
                            
                        }
                 
                    ).ToList();
                    
            }

            return View();
        }
    }
}

                                                