using Fhi.Kompetanse.Risk.Domenemodell.Valuetypes;

namespace Fhi.Kompetanse.Risk.Domenemodell.Entities;

public class RiskSpill : BaseEntity
{
    public int RiskSpillId { get; set; }
    public RiskSpillStatus RiskSpillStatus { get; set; }=RiskSpillStatus.Opprettet;
    public DateTime Opprettet { get; set; }
}
