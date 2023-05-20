namespace DVHTUS.Models
{
    public class LopHP
    {
        public int ID { get; set; }
        public string? TenLopHP { get; set; }
        public string? Khoa { get; set; }
        public int SoLuong { get; set; }
        public ICollection<DangKyHocPhan>? DangKyHocPhans { get; set; }
    }
}
