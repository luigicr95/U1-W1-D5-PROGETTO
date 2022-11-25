using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_W1_D5_PROGETTO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contribuente contribuente = new Contribuente();
            contribuente.ApriProgramma();
            Console.ReadLine();
        }

        public class Contribuente
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public string ComuneResidenza { get; set; }
            public DateTime DataDiNascita { get; set; }
            public string CodiceFiscale { get; set; }
            public string Sesso { get; set; }
            public decimal RedditoAnnuale { get; set; }
            public decimal ImpostaDaVersare { get; set; }


            public void ApriProgramma()
            {
                
                InserisciNome();

                InserisciCognome();

                InserisciComune();

                InserisciDataDiNascita();

                InserisciCodiceFiscale();

                InserireSesso();    

                InserireReddito();

                CalcoloImposta();

                MostraDati();

                ApriProgramma();
               
            }

            public void InserisciNome()
            {
                Console.WriteLine("Inserisci il tuo nome:");
                string nomeStringa = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nomeStringa))
                {
                    Console.WriteLine("Questo campo è necessario");
                    InserisciNome();
                } else
                {
                    Nome = nomeStringa;
                }
            }

            public void InserisciCognome()
            {
                Console.WriteLine("Inserisci il tuo cognome:");
                string cognomeStringa = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(cognomeStringa))
                {
                    Console.WriteLine("Questo campo è necessario");
                    InserisciCognome();
                }
                else
                {
                    Cognome = cognomeStringa;
                }
            }

            public void InserisciComune()
            {
                Console.WriteLine("Inserisci il tuo comune di residenza:");
                string comuneStringa = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(comuneStringa))
                {
                    Console.WriteLine("Questo campo è necessario");
                    InserisciComune();
                }
                else
                {
                    Cognome = comuneStringa;
                }
            }

            public void InserisciDataDiNascita()
            {
                try
                {
                    Console.WriteLine("Inserisci la tua data di nascita (dd/MM/yyyy):");
                    string dataStringa = Console.ReadLine();
                    DataDiNascita = DateTime.ParseExact(dataStringa, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    InserisciDataDiNascita();
                }
            }


            public void InserisciCodiceFiscale()
            {
                Console.WriteLine("Inserisci il tuo CodiceFiscale:");
                string codiceStringa = Console.ReadLine();
                if (codiceStringa.Length < 16)
                {
                    Console.WriteLine("Controlla di aver digitato il Codice Fiscale correttamente");
                    InserisciCodiceFiscale();
                }
                else
                {
                    CodiceFiscale = codiceStringa;
                }
            }

            public void InserireReddito()
            {
                try
                {
                    Console.WriteLine("Inserisci il tuo Reddito Annuale:");
                    RedditoAnnuale = decimal.Parse(Console.ReadLine());
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    InserireReddito();
                }
            }

            public void InserireSesso()
            {
                Console.WriteLine("Inserisci il tuo sesso M/F:");
                string sceltaSesso = Console.ReadLine();
                if (sceltaSesso.ToUpper() == "M" || sceltaSesso.ToUpper() == "F")
                {
                    Sesso = sceltaSesso;
                }
                else
                {
                    Console.WriteLine("Inserisci una scelta valida");
                    InserireSesso();
                    
                }
            }

            public void CalcoloImposta()
            {
                if (RedditoAnnuale <= 15000)
                {
                    ImpostaDaVersare = RedditoAnnuale * 23 / 100;
                } else if (RedditoAnnuale > 15000 && RedditoAnnuale <= 28000 )
                {
                    ImpostaDaVersare = (RedditoAnnuale - 15000) * 27 / 100 + 3450;
                }
                else if (RedditoAnnuale > 28000 && RedditoAnnuale <= 55000)
                {
                    ImpostaDaVersare = (RedditoAnnuale - 28000) * 38 / 100 + 6960;
                }
                else if (RedditoAnnuale > 55000 && RedditoAnnuale <= 75000)
                {
                    ImpostaDaVersare = (RedditoAnnuale - 55000) * 41 / 100 + 17220;
                }
                else if (RedditoAnnuale > 75000)
                {
                    ImpostaDaVersare = (RedditoAnnuale - 75000) * 43 / 100 + 25420;
                }

            }

            public void MostraDati()
            {
                Console.WriteLine("");
                Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE");
                Console.WriteLine("");
                Console.WriteLine($"Contribuente: {Nome} {Cognome}");
                Console.WriteLine($"nato il {DataDiNascita} ({Sesso.ToUpper()})");
                Console.WriteLine($"residente in {ComuneResidenza}");
                Console.WriteLine($"codice fiscale: {CodiceFiscale.ToUpper()}");
                Console.WriteLine("");
                Console.WriteLine($"Reddito dichiarato: {RedditoAnnuale}");
                Console.WriteLine("");
                Console.WriteLine($"Imposta da versare: {ImpostaDaVersare}");
                Console.WriteLine("");
            }

        }
    }
}
