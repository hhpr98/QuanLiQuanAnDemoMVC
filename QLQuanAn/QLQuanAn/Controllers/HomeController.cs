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
        public ActionResult Details(int id)
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
            List<ChuoiCuaHang> l;
            using (var qlqa = new QuanLiQuanAnEntities())
            {
                l = qlqa.ChuoiCuaHangs.ToList();
            }
                return View("Add",l);
        }

        public ActionResult AddGet()
        {
            List<ChuoiCuaHang> l;
            using (var qlqa = new QuanLiQuanAnEntities())
            {
                l = qlqa.ChuoiCuaHangs.ToList();
            }
            ViewBag.curId = -1;
            return View(new Tuple<List<ChuoiCuaHang>, List<CuaHang>>(l, null));
        }

        public ActionResult Edit(int id)
        {
            List<ChuoiCuaHang> listChuoi;
            CuaHang ch;
            using (var qlqa = new QuanLiQuanAnEntities())
            {
                listChuoi = qlqa.ChuoiCuaHangs.ToList();
                List<CuaHang> listCuaHang = qlqa.CuaHangs.Where(c => c.ID == id).ToList();
                ch = listCuaHang[0];
            }
            ViewBag.curId = id;
            return View("Edit", new Tuple<List<ChuoiCuaHang>, CuaHang>(listChuoi, ch));
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