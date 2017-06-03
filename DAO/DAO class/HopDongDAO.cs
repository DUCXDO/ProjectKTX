﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IHopDongDAO
    {
        HOPDONG ThemHD(HOPDONG hd);
        HOPDONG XoaHD(HOPDONG hd);
        IEnumerable<HOPDONG> TimTatCaHD();
        IEnumerable<HOPDONG> TimHD(HOPDONG hd);
    }

    public class HopDongDAO : IHopDongDAO
    {
        public HOPDONG ThemHD(HOPDONG hd)
        {

            // khai báo và khởi tạo đối tượng kết nối với database
            KTXEntities KTXe = new KTXEntities();
            //Thêm mới 
            HOPDONG result = KTXe.HOPDONGs.Add(hd);
            //Lưu thay đổi
            KTXe.SaveChanges();
            //trả về đối tượng mới thêm để xác định kết quả
            return result;

        }

        public HOPDONG XoaHD(HOPDONG hd)
        {

            KTXEntities KTXe = new KTXEntities();
            HOPDONG delete = KTXe.HOPDONGs.Find(hd.MaSV);
            HOPDONG result = KTXe.HOPDONGs.Remove(delete);
            return result;

        }


        public IEnumerable<HOPDONG> TimTatCaHD()
        {

            KTXEntities KTXe = new KTXEntities();
            IEnumerable<HOPDONG> result = KTXe.HOPDONGs.AsEnumerable();
            return result;

        }


        public IEnumerable<HOPDONG> TimHD(HOPDONG hd)
        {

            KTXEntities KTXe = new KTXEntities();
            IEnumerable<HOPDONG> result = KTXe.HOPDONGs.AsQueryable().Where(x =>
            (hd.MaSV == null || x.MaSV == hd.MaSV) &&
            (hd.SoHD == null || x.SoHD == hd.SoHD) &&
            (hd.MaPhong == null) || (x.MaPhong == hd.MaPhong) &&
            (hd.NgayLap == null) || (x.NgayLap == hd.NgayLap));
            return result;

        }
    }
}
