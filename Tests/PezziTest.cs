using System;
using System.Linq;
using Scacchi.Modello.Pezzi;
using Xunit;

namespace Scacchi.Modello
{
  public class PezziTest
  {

    [Theory]
    [InlineData(typeof(Donna))]
    [InlineData(typeof(Pedone))]
    [InlineData(typeof(Cavallo))]
    [InlineData(typeof(Alfiere))]
    [InlineData(typeof(Re))]
    [InlineData(typeof(Torre))]
    public void IPezziNonPossonoRestareFermi(Type t) {
      //Given
      IPezzo pezzo = Activator.CreateInstance(t, Colore.Bianco) as IPezzo;
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = pezzo.PuòMuovere(Colonna.A, Traversa.Prima, Colonna.A, 
      Traversa.Prima, scacchiera);
      //Then
      Assert.False(esito, t.Name);
    }
    /*--------------------------------------PEDONE------------------------------------------ */
    
    [Fact]
    public void IlPedoneBiancoPuoMuovereAvantiDiUnaCasa()
    {
      //Given
      Pedone pedone = new Pedone(Colore.Bianco);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = pedone.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Seconda,
      colonnaArrivo: Colonna.A,
      traversaArrivo: Traversa.Terza,
      scacchiera: scacchiera);

      //Then
      Assert.True(esito);
    }

    [Fact]
    public void IlPedoneBiancoNonPuoMuovereIndietroDiUnaCasa(){
      //Given
      Pedone pedone = new Pedone(Colore.Bianco);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = pedone.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Settima,
      colonnaArrivo: Colonna.A,
      traversaArrivo: Traversa.Sesta,
      scacchiera: scacchiera);
      //Then
      Assert.False(esito);
    }

    [Fact]
    public void IlPedoneNeroNonPuoMuovereIndietroDiUnaCasa(){
      //Given
      Pedone pedone = new Pedone(Colore.Nero);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = pedone.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Terza,
      colonnaArrivo: Colonna.A,
      traversaArrivo: Traversa.Quarta,
      scacchiera: scacchiera);
      //Then
      Assert.False(esito);
    }

    [Fact]
    public void IlPedoneBiancoPuoMuovereAvantiDiDueCaseDallaSecondaTravers(){
      //Given
      Pedone pedone = new Pedone(Colore.Bianco);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = pedone.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Seconda,
      colonnaArrivo: Colonna.A,
      traversaArrivo: Traversa.Quarta,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);
    }

    [Fact]
    public void IlPedoneNeroPuoMuovereAvantiDiDueCaseDallaSettimaTravers(){
      //Given
      Pedone pedone = new Pedone(Colore.Nero);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = pedone.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Settima,
      colonnaArrivo: Colonna.A,
      traversaArrivo: Traversa.Quinta,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);
    }
    
    [Theory]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.B, Traversa.Terza,
    Colore.Bianco, Colonna.B, Traversa.Terza)]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.B, Traversa.Quarta,
    Colore.Bianco,Colonna.B, Traversa.Terza)]
    [InlineData(Colonna.B,Traversa.Settima, Colonna.B, Traversa.Sesta,
    Colore.Nero, Colonna.B, Traversa.Sesta)]
    [InlineData(Colonna.B,Traversa.Settima, Colonna.B, Traversa.Quinta,
    Colore.Nero, Colonna.B, Traversa.Sesta)]
    public void ilPedoneNonSiPuòMuovereSeHaUnPezzoDavanti(
    Colonna colonnaPartenza, Traversa traversaPartenza,
    Colonna colonnaArrivo, Traversa traversaArrivo,
    Colore colore, Colonna colonnaPezzoBloccante,
    Traversa traversaPezzoBloccante){
      //Given
      Pedone pedone = new Pedone(colore);
      Scacchiera scacchiera = new Scacchiera();
      scacchiera[colonnaPezzoBloccante, traversaPezzoBloccante].PezzoPresente = 
      new Pedone(Colore.Bianco);
      //When
      bool esito = pedone.PuòMuovere(colonnaPartenza, traversaPartenza,
      colonnaArrivo, traversaArrivo,scacchiera);
      //Then
      Assert.False(esito);
    }

    [Theory]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.C, Traversa.Terza,
    Colore.Bianco, Colore.Nero, Colonna.C, Traversa.Terza)]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.A, Traversa.Terza,
    Colore.Bianco, Colore.Nero,Colonna.A, Traversa.Terza)]
    [InlineData(Colonna.B,Traversa.Settima, Colonna.C, Traversa.Sesta,
    Colore.Nero, Colore.Bianco, Colonna.C, Traversa.Sesta)]
    [InlineData(Colonna.B,Traversa.Settima, Colonna.A, Traversa.Sesta,
    Colore.Nero, Colore.Bianco, Colonna.A, Traversa.Sesta)]
    public void ilPedonePuòMangiareUnPezzoAvversarioInDiagonaleDiUno(
    Colonna colonnaPartenza, Traversa traversaPartenza,
    Colonna colonnaArrivo, Traversa traversaArrivo,
    Colore colore, Colore colorePezzoBloccante,
    Colonna colonnaPezzoBloccante,
    Traversa traversaPezzoBloccante){
      //Given
      Pedone pedone = new Pedone(colore);
      Scacchiera scacchiera = new Scacchiera();
      scacchiera[colonnaPezzoBloccante, traversaPezzoBloccante].PezzoPresente = 
      new Pedone(colorePezzoBloccante);
      //When
      bool esito = pedone.PuòMuovere(colonnaPartenza, traversaPartenza,
      colonnaArrivo, traversaArrivo,scacchiera);
      //Then
      Assert.True(esito);
    }

    [Theory]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.C, Traversa.Terza,
    Colore.Bianco, Colore.Bianco, Colonna.C, Traversa.Terza)]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.A, Traversa.Terza,
    Colore.Bianco, Colore.Bianco,Colonna.A, Traversa.Terza)]
    [InlineData(Colonna.B,Traversa.Settima, Colonna.C, Traversa.Sesta,
    Colore.Nero, Colore.Nero, Colonna.C, Traversa.Sesta)]
    [InlineData(Colonna.B,Traversa.Settima, Colonna.A, Traversa.Sesta,
    Colore.Nero, Colore.Nero, Colonna.A, Traversa.Sesta)]
    public void ilPedoneNonPuòMangiareUnPezzoDelloStessoColoreInDiagonaleDiUno(
    Colonna colonnaPartenza, Traversa traversaPartenza,
    Colonna colonnaArrivo, Traversa traversaArrivo,
    Colore colore, Colore colorePezzoBloccante,
    Colonna colonnaPezzoBloccante,
    Traversa traversaPezzoBloccante){
      //Given
      Pedone pedone = new Pedone(colore);
      Scacchiera scacchiera = new Scacchiera();
      scacchiera[colonnaPezzoBloccante, traversaPezzoBloccante].PezzoPresente = 
      new Pedone(colorePezzoBloccante);
      //When
      bool esito = pedone.PuòMuovere(colonnaPartenza, traversaPartenza,
      colonnaArrivo, traversaArrivo,scacchiera);
      //Then
      Assert.False(esito);
    }
    /*--------------------------------------------TORRE--------------------------------------- */
    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void LaTorrePuoMuovereInVerticale(Colore colore){
      //Given
      Torre torre = new Torre(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = torre.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Prima,
      colonnaArrivo: Colonna.A,
      traversaArrivo: Traversa.Sesta,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);

    }
    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void LaTorrePuoMuovereInOrizzontale(Colore colore){
      //Given
      Torre torre = new Torre(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = torre.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Prima,
      colonnaArrivo: Colonna.F,
      traversaArrivo: Traversa.Prima,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);
    }
    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void LaTorreNonPuoMuovereInDiagonale(Colore colore){
      //Given
      Torre torre = new Torre(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = torre.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Prima,
      colonnaArrivo: Colonna.F,
      traversaArrivo: Traversa.Quarta,
      scacchiera: scacchiera);
      //Then
      Assert.False(esito);
    }

    [Theory]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.B, Traversa.Settima,
    Colore.Bianco, Colore.Nero, Colonna.B, Traversa.Terza)]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.H, Traversa.Seconda,
    Colore.Bianco, Colore.Bianco, Colonna.F, Traversa.Seconda)]
    [InlineData(Colonna.B,Traversa.Settima, Colonna.B, Traversa.Seconda,
    Colore.Nero, Colore.Bianco, Colonna.B, Traversa.Sesta)]
    [InlineData(Colonna.D,Traversa.Settima, Colonna.A, Traversa.Settima,
    Colore.Nero, Colore.Nero, Colonna.A, Traversa.Settima)]
    public void laTorreNonSiPuòMuovereSeUnPezzoBloccaLoSpostamento(
    Colonna colonnaPartenza, Traversa traversaPartenza,
    Colonna colonnaArrivo, Traversa traversaArrivo,
    Colore colore, Colore colorePezzoBloccante,
    Colonna colonnaPezzoBloccante,
    Traversa traversaPezzoBloccante){
      //Given
      Torre torre = new Torre(colore);
      Scacchiera scacchiera = new Scacchiera();
      scacchiera[colonnaPezzoBloccante, traversaPezzoBloccante].PezzoPresente = 
      new Pedone(colorePezzoBloccante);
      //When
      bool esito = torre.PuòMuovere(colonnaPartenza, traversaPartenza,
      colonnaArrivo, traversaArrivo, scacchiera);
      //Then
      Assert.False(esito);
    }

    [Theory]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.B, Traversa.Settima,
    Colore.Bianco, Colore.Nero, Colonna.B, Traversa.Settima)]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.H, Traversa.Seconda,
    Colore.Bianco, Colore.Nero, Colonna.H, Traversa.Seconda)]
    [InlineData(Colonna.B,Traversa.Settima, Colonna.B, Traversa.Seconda,
    Colore.Nero, Colore.Bianco, Colonna.B, Traversa.Seconda)]
    [InlineData(Colonna.D,Traversa.Settima, Colonna.A, Traversa.Settima,
    Colore.Nero, Colore.Bianco, Colonna.A, Traversa.Settima)]
    public void laTorrePuòMangiarePezzoAvversarioInOrizzontaleEVerticale(
    Colonna colonnaPartenza, Traversa traversaPartenza,
    Colonna colonnaArrivo, Traversa traversaArrivo,
    Colore colore, Colore colorePezzoBloccante,
    Colonna colonnaPezzoBloccante,
    Traversa traversaPezzoBloccante){
      //Given
      Torre torre = new Torre(colore);
      Scacchiera scacchiera = new Scacchiera();
      scacchiera[colonnaPezzoBloccante, traversaPezzoBloccante].PezzoPresente = 
      new Pedone(colorePezzoBloccante);
      //When
      bool esito = torre.PuòMuovere(colonnaPartenza, traversaPartenza,
      colonnaArrivo, traversaArrivo, scacchiera);
      //Then
      Assert.True(esito);
    }
    /*--------------------------------------ALFIERE------------------------------- */
    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void LAlfierePuoMuovereInDiagonale(Colore colore){
      //Given
      Alfiere alfiere = new Alfiere(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = alfiere.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Prima,
      colonnaArrivo: Colonna.F,
      traversaArrivo: Traversa.Sesta,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);
    }
    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void LAlfierePuoMuovereSoloInDiagonale(Colore colore){
      //Given
      Alfiere alfiere = new Alfiere(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = alfiere.PuòMuovere(
      colonnaPartenza: Colonna.F,
      traversaPartenza: Traversa.Ottava,
      colonnaArrivo: Colonna.C,
      traversaArrivo: Traversa.Quarta,
      scacchiera: scacchiera);
      //Then
      Assert.False(esito);
    }

    [Theory]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.G, Traversa.Settima,
    Colore.Bianco, Colore.Nero, Colonna.D, Traversa.Quarta)]
    [InlineData(Colonna.B,Traversa.Ottava, Colonna.G, Traversa.Terza,
    Colore.Bianco, Colore.Bianco, Colonna.E, Traversa.Quinta)]
    [InlineData(Colonna.F,Traversa.Settima, Colonna.C, Traversa.Quarta,
    Colore.Nero, Colore.Bianco, Colonna.E, Traversa.Sesta)]
    [InlineData(Colonna.D,Traversa.Terza, Colonna.H, Traversa.Settima,
    Colore.Nero, Colore.Nero, Colonna.H, Traversa.Settima)]
    public void lAlfiereNonSiPuòMuovereSeUnPezzoBloccaLoSpostamento(
    Colonna colonnaPartenza, Traversa traversaPartenza,
    Colonna colonnaArrivo, Traversa traversaArrivo,
    Colore colore, Colore colorePezzoBloccante,
    Colonna colonnaPezzoBloccante,
    Traversa traversaPezzoBloccante){
      //Given
      Alfiere alfiere = new Alfiere(colore);
      Scacchiera scacchiera = new Scacchiera();
      scacchiera[colonnaPezzoBloccante, traversaPezzoBloccante].PezzoPresente = 
      new Pedone(colorePezzoBloccante);
      //When
      bool esito = alfiere.PuòMuovere(colonnaPartenza, traversaPartenza,
      colonnaArrivo, traversaArrivo, scacchiera);
      //Then
      Assert.False(esito);
    }

    /*--------------------------------CAVALLO---------------------------------------- */

    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void IlCavalloPuoMuovereAdL(Colore colore){
      //Given
      Cavallo cavallo = new Cavallo(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = cavallo.PuòMuovere(
      colonnaPartenza: Colonna.B,
      traversaPartenza: Traversa.Prima,
      colonnaArrivo: Colonna.A,
      traversaArrivo: Traversa.Terza,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);
    }

    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void IlCavalloPuoMuovereSoloAdL(Colore colore){
      //Given
      Cavallo cavallo = new Cavallo(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = cavallo.PuòMuovere(
      colonnaPartenza: Colonna.G,
      traversaPartenza: Traversa.Ottava,
      colonnaArrivo: Colonna.E,
      traversaArrivo: Traversa.Sesta,
      scacchiera: scacchiera);
      //Then
      Assert.False(esito);
    }
/*
    [Theory]
    [InlineData(Colonna.B,Traversa.Seconda, Colonna.G, Traversa.Settima,
    Colore.Bianco, Colore.Nero, Colonna.D, Traversa.Quarta)]
    [InlineData(Colonna.B,Traversa.Ottava, Colonna.G, Traversa.Terza,
    Colore.Bianco, Colore.Bianco, Colonna.E, Traversa.Quinta)]
    [InlineData(Colonna.F,Traversa.Settima, Colonna.C, Traversa.Quarta,
    Colore.Nero, Colore.Bianco, Colonna.E, Traversa.Sesta)]
    [InlineData(Colonna.D,Traversa.Terza, Colonna.H, Traversa.Settima,
    Colore.Nero, Colore.Nero, Colonna.H, Traversa.Settima)]
    public void ilCavalloNonSiPuòMuovereSeLaCasaDiArrivoÈOccupata(
    Colonna colonnaPartenza, Traversa traversaPartenza,
    Colonna colonnaArrivo, Traversa traversaArrivo,
    Colore colore, Colore colorePezzoBloccante,
    Colonna colonnaPezzoBloccante,
    Traversa traversaPezzoBloccante){
      //Given
      Alfiere alfiere = new Alfiere(colore);
      Scacchiera scacchiera = new Scacchiera();
      scacchiera[colonnaPezzoBloccante, traversaPezzoBloccante].PezzoPresente = 
      new Pedone(colorePezzoBloccante);
      //When
      bool esito = alfiere.PuòMuovere(colonnaPartenza, traversaPartenza,
      colonnaArrivo, traversaArrivo, scacchiera);
      //Then
      Assert.False(esito);
    }
*/
    /*------------------------------------Donna-------------------------------------- */
    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void LaDonnaPuoMuovereInVerticale(Colore colore){
      //Given
      Donna donna = new Donna(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = donna.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Prima,
      colonnaArrivo: Colonna.A,
      traversaArrivo: Traversa.Sesta,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);

    }
    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void LaDonnaPuoMuovereInOrizzontale(Colore colore){
      //Given
      Donna donna = new Donna(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = donna.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Prima,
      colonnaArrivo: Colonna.F,
      traversaArrivo: Traversa.Prima,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);
    }

    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void LaDonnaPuoMuovereInDiagonale(Colore colore){
      //Given
      Donna donna = new Donna(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = donna.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Prima,
      colonnaArrivo: Colonna.F,
      traversaArrivo: Traversa.Sesta,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);
    }

    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void LaDonnaPuoMuovereSoloInDiagonaleOrizzontaleVerticale(Colore colore){
      //Given
      Donna donna = new Donna(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = donna.PuòMuovere(
      colonnaPartenza: Colonna.F,
      traversaPartenza: Traversa.Ottava,
      colonnaArrivo: Colonna.C,
      traversaArrivo: Traversa.Quarta,
      scacchiera: scacchiera);
      //Then
      Assert.False(esito);
    }

    /*-----------------------------------------RE--------------------------------------------- */
    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void IlRePuoMuovereInVerticaleDiUno(Colore colore){
      //Given
      Re re = new Re(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = re.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Prima,
      colonnaArrivo: Colonna.A,
      traversaArrivo: Traversa.Seconda,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);

    }
    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void IlRePuoMuovereInOrizzontaleDiUno(Colore colore){
      //Given
      Re re = new Re(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = re.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Prima,
      colonnaArrivo: Colonna.B,
      traversaArrivo: Traversa.Prima,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);
    }

    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void IlRePuoMuovereInDiagonaleDiUno(Colore colore){
      //Given
      Re re = new Re(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = re.PuòMuovere(
      colonnaPartenza: Colonna.A,
      traversaPartenza: Traversa.Prima,
      colonnaArrivo: Colonna.B,
      traversaArrivo: Traversa.Seconda,
      scacchiera: scacchiera);
      //Then
      Assert.True(esito);
    }

    [Theory]
    [InlineData(Colore.Bianco)]
    [InlineData(Colore.Nero)]
    public void IlRePuoMuovereSoloDiUno(Colore colore){
      //Given
      Re re = new Re(colore);
      Scacchiera scacchiera = new Scacchiera();
      //When
      bool esito = re.PuòMuovere(
      colonnaPartenza: Colonna.F,
      traversaPartenza: Traversa.Ottava,
      colonnaArrivo: Colonna.C,
      traversaArrivo: Traversa.Quarta,
      scacchiera: scacchiera);
      //Then
      Assert.False(esito);
    }

  }
}
