namespace Scacchi.Modello
{
    public interface IScacchiera
    {
        ICasa[] Case { get; }
        ICasa this[Colonna colonna, Traversa traversa]{get;}
    }
}