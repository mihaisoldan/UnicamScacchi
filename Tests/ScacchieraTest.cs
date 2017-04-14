using System;
using System.Linq;
using Scacchi.Modello;
using Scacchi.Modello.Pezzi;
using Xunit;

namespace Scacchi.Tests{

  public class ScacchieraTest{

    [Fact]
    public void ScacchieraDeveAvere64Case()
    {
      //Given
      IScacchiera scacchiera= new Scacchiera();
      //When

      //Then
      Assert.Equal(64, scacchiera.Case.Count());
    }
    [Fact]
    public void indexerDeveRestituireCasaCorretta()
    {
      //Given
      IScacchiera scacchiera= new Scacchiera();
      //When
      ICasa casa= scacchiera[Colonna.F,Traversa.Quinta];
      //Then
      Assert.Equal(Colonna.F, casa.Colonna);
      Assert.Equal(Traversa.Quinta, casa.Traversa);
    }

    [Fact]
    public void sePezzoNonPresenteIlGetterRitornaNull(){
      //Given
      IScacchiera scacchiera = new Scacchiera();
      //When
      ICasa casa = scacchiera[Colonna.B,Traversa.Prima];
      //Then
      Assert.Null(casa.PezzoPresente);
    }
    [Theory]
    [InlineData(typeof(Alfiere),Colore.Bianco,Colonna.C,Traversa.Prima)]
    [InlineData(typeof(Donna),Colore.Nero,Colonna.D,Traversa.Ottava)]
    [InlineData(typeof(Pedone),Colore.Bianco,Colonna.F,Traversa.Seconda)]
    [InlineData(typeof(Cavallo),Colore.Nero,Colonna.G,Traversa.Ottava)]
    [InlineData(typeof(Torre),Colore.Nero,Colonna.H,Traversa.Ottava)]
    public void iPezziVengonoInseritiNellaPosizioneGiusta(Type pezzo,
    Colore colore, Colonna colonna, Traversa traversa){
      //Given
      Scacchiera scacchiera = new Scacchiera();
      //When
      scacchiera.disponiPezziInConfigurazioneIniziale();
      ICasa casa = scacchiera[colonna, traversa];
      //Then
      Assert.Equal(casa.PezzoPresente.GetType(), pezzo);
      Assert.Equal(casa.PezzoPresente.Colore, colore);     
    }
  }
}
