namespace DVHTUS.Models
{
    public class DangKyHocPhan
    {
        public int ID { get; set; }
        public DateTime NgayDangKy { get; set; }
        public int SinhVienID { get; set; }
        public int LopHPID { get; set; }
        public SinhVien? SinhVien { get; set; }
        public LopHP? LopHP { get; set; }
    }
}
