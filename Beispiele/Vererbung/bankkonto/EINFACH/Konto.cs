
using System;


namespace Konto
{

public class Konto 
{
	private string mKontoNummer;//Variable / Attribute für Kontnummer
	private double mKontoStand;//Variable / Attribute für KontoStand


	/// <summary>
	/// Konstruktor zur Initialisierung für kontoNummer und kontoStand.
	/// </summary>
	/// <param name="nummer">vom Typ string weist der kontoNummer</param>
	/// <param name="betrag">vom Typ double weist dem kontoStand</param>
	public Konto (string nummer, double betrag) 
	{
		this.mKontoNummer = nummer;
		this.mKontoStand = betrag;
	}


    /// <summary>
    /// Konstruktor zur Initialisierung für kontoNummer. Der kontoStand wird mit Null 
    /// initialisiert
    /// </summary>
    /// <param name="nummer">kontonumbe als string</param>
	public Konto (string nummer)
	{
        mKontoNummer = nummer;
        mKontoStand = 0;
	}

   

    ~Konto()  // destructor
    {
        // cleanup statements...
    }


	public double gibKontostand()
    {
			return mKontoStand;
    }

   
  
	/// <summary>
	/// Methode einzahlen erhöht den kontoStand um den Betrag der als
	/// Parameter angegeben wird
	/// </summary>
	/// <param name="betrag">Einzahlungbetrag</param>
	public void einzahlen (double betrag) 
	{
		mKontoStand += betrag;//mKontoStand=mKontoStand+betrag;
	}

	
	/// <summary>
	/// Methode abheben reduziert den kontoStand um den Betrag der als
	/// Parameter angegeben wird. Es kann maximal der Betrag abgehoben werden, der dem 
	/// kontoStand entspricht.
	/// </summary>
    /// <param name="betrag">etrag vom Typ double reduziert dem kontoStand</param>
	/// <returns>true wenn gülitg</returns>
	public bool abheben(double betrag) 
	{
		bool valid = mKontoStand-betrag > 0;
		if (valid)
			mKontoStand -= betrag;
		return valid;	
	}
	
    
	/// <summary>
	/// Methode auszug zeigt kontoNummer und kontoStand an.
	/// </summary>
	public void auszug() 
	{
		Console.WriteLine("Konto          : "+mKontoNummer);
		Console.WriteLine("Kontostand Fr. : "+mKontoStand);
	}

    

	/// <summary>
	/// Methode toString gibt die kontoNummer und den kontoStand.
	/// als String zurück.
	/// </summary>
	/// <returns>Kontoasuzug als string</returns>
	public override string ToString() 
	{
		string ausgabe = "Konto "+mKontoNummer+" (Kontostand "+ mKontoStand +")";
		return ausgabe;
	}
}

public class Sparkonto : Konto
    {
		private double mZinsSatz;

		public Sparkonto(string kontonummer,double zinsSatz):base(kontonummer)
        {
			mZinsSatz = zinsSatz;
			Console.WriteLine("Sparkonto initialisiert.");
        }

		public void saldieren()
        {
			einzahlen(mZinsSatz * gibKontostand() / 100);
        }

		public void auszug()
        {
			base.auszug();
			Console.WriteLine("Zinssatz: " + mZinsSatz + " %");

        }
    }
}
