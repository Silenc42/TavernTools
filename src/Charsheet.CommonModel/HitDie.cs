namespace Charsheet.CommonModel;

public class HitDie
{
    public HitDie(int roll, int hdSize)
    {
        Roll = roll;
        HdSize = hdSize;
    }

    public int Roll { get; init; }
    public int HdSize { get; init; }
}
