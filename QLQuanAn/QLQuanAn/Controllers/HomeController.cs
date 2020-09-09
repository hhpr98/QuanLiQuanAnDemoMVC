using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLQuanAn.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            List<ChuoiCuaHang> l;
            using (var qlqa = new QuanLiQuanAnEntities())
            {
                l = qlqa.ChuoiCuaHangs.ToList();
            }
            ViewBag.curId = -1;
            return View(new Tuple<List<ChuoiCuaHang>, List<CuaHang>>(l, null));
        }

        // GET: CuaHangs
        public ActionResult MartDetails(int id)
        {
            List<ChuoiCuaHang> listChuoi;
            List<CuaHang> listCuaHang;
            using (var qlqa = new QuanLiQuanAnEntities())
            {
                listChuoi = qlqa.ChuoiCuaHangs.ToList();

                listCuaHang = qlqa.CuaHangs.Where(c => c.ChuoiCuaHang == id).ToList();
            }
            ViewBag.curId = id;
            return View("Index", new Tuple<List<ChuoiCuaHang>, List<CuaHang>>(listChuoi, listCuaHang));
        }

        public ActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public ActionResult Add(string name,string address,double total,int number,int chuoi)
        {
            using (var db = new QuanLiQuanAnEntities())
            {
                var _mart = new CuaHang();
                _mart.TenCuaHang = name;
                _mart.DiaChi = address;
                _mart.DoanhThu = total;
                _mart.SoKhach = number;
                _mart.ChuoiCuaHang = chuoi;
                db.CuaHangs.Add(_mart);
                db.SaveChanges();
            }    

            // return về view index
            List<ChuoiCuaHang> l;
            using (var qlqa = new QuanLiQuanAnEntities())
            {
                l = qlqa.ChuoiCuaHangs.ToList();
            }
            ViewBag.curId = -1;
            return View("Index",new Tuple<List<ChuoiCuaHang>, List<CuaHang>>(l, null));
        }

        public ActionResult Edit(int id)
        {
            CuaHang cuaHang;
            List<ChuoiCuaHang> listChuoi;
            using (var qlqa = new QuanLiQuanAnEntities())
            {
                listChuoi = qlqa.ChuoiCuaHangs.ToList();
                cuaHang = qlqa.CuaHangs.Where(c => c.ID == id).First();
            }
            return View("Edit", new Tuple<List<ChuoiCuaHang>, CuaHang>(listChuoi, cuaHang));
        }

        [HttpPost]
        public ActionResult ConfirmEdit(int id,string name, string address, double total, int number, int chuoi)
        {
            using (var db = new QuanLiQuanAnEntities())
            {
                var _mart = db.CuaHangs.Find(id);
                _mart.TenCuaHang = name;
                _mart.DiaChi = address;
                _mart.DoanhThu = total;
                _mart.SoKhach = number;
                _mart.ChuoiCuaHang = chuoi;
                db.SaveChanges();
            }

            // return về view index
            List<ChuoiCuaHang> l;
            using (var qlqa = new QuanLiQuanAnEntities())
            {
                l = qlqa.ChuoiCuaHangs.ToList();
            }
            ViewBag.curId = -1;
            return View("Index", new Tuple<List<ChuoiCuaHang>, List<CuaHang>>(l, null));
        }

        public ActionResult Detete(int id)
        {
            using (var qlqa = new QuanLiQuanAnEntities())
            {
                CuaHang ch = qlqa.CuaHangs.Find(id);
                qlqa.CuaHangs.Remove(ch);
                qlqa.SaveChanges();
            }

            List<ChuoiCuaHang> listChuoi;
            List<CuaHang> listCuaHang;
            using (var qlqa = new QuanLiQuanAnEntities())
            {
                listChuoi = qlqa.ChuoiCuaHangs.ToList();

                listCuaHang = qlqa.CuaHangs.Where(c => c.ChuoiCuaHang == id).ToList();
            }
            ViewBag.curId = id;
            return View("Index", new Tuple<List<ChuoiCuaHang>, List<CuaHang>>(listChuoi, listCuaHang));
        }
    }
}