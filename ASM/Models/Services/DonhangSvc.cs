using Microsoft.EntityFrameworkCore;

namespace ASM.Models.Services
{
    public interface IDonhangSvc
    {
        List<Donhang> GetDonhangAll();
        List<Donhang> GetDonhangbyKhachhang(int khachhangId);
        Donhang GetDonhang(int id);
        int AddDonhang(Donhang donhang);
        int EditDonhang(int id, Donhang donhang);
    }
    public class DonhangSvc : IDonhangSvc
    {
        protected DataContext _context;
        public DonhangSvc(DataContext context)
        {
            _context = context;
        }

        public int AddDonhang(Donhang donhang)
        {
            int ret = 0;
            try
            {
                _context.Add(donhang);
                _context.SaveChanges();
                ret = donhang.DonhangID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int EditDonhang(int id, Donhang donhang)
        {
            int ret = 0;
            try
            {
                Donhang _donhang = null;
                _donhang = _context.Donhangs.Find(id);
                _donhang.TrangthaiDonhang = donhang.TrangthaiDonhang;
                _donhang.Ghichu = donhang.Ghichu;
                _context.Update(_donhang);
                _context.SaveChanges();
                ret = donhang.DonhangID;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public Donhang GetDonhang(int id)
        {
            Donhang donhang = null;
            donhang = _context.Donhangs.Where(x => x.DonhangID == id)
                .Include(x => x.Khachhang)
                .Include(x => x.DonhangChitiets).ThenInclude(y => y.MonAn).FirstOrDefault();
            return donhang;
        }

        public List<Donhang> GetDonhangAll()
        {
            List<Donhang> list = new List<Donhang>();
            list = _context.Donhangs.OrderByDescending(x => x.Ngaydat)
                .Include(x => x.Khachhang)
                .Include(x => x.DonhangChitiets)
                .ToList();
            return list;
        }

        public List<Donhang> GetDonhangbyKhachhang(int khachhangId)
        {
            List<Donhang> list = new List<Donhang> ();
            list = _context.Donhangs.Where(x => x.KhachhangID == khachhangId).OrderByDescending(x => x.Ngaydat)
                .Include(x => x.Khachhang)
                .Include(x => x.DonhangChitiets)
                .ToList();
            return list;
        }
    }
}
