﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NumberGuesser.Model;

namespace NumberGuesser
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber SecretNumber
        {
            get
            {
                if (Session["SecretNumber"] == null)
                {
                    Session["SecretNumber"] = new SecretNumber(); //starta ny session om det inte finns en redan
                }
                return Session["SecretNumber"] as SecretNumber; //skicka tillbaka sessionen
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MakeGuess_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int guess = int.Parse(GuessInput.Text);
                Outcome result = SecretNumber.MakeGuess(guess); //testa gissningen
                GuessOutcome.Text = string.Join(", ", SecretNumber.PreviousGuesses); //visa alla gissningar
                if (result == Outcome.Low)
                {
                    GuessOutcome.Text += " ⇩ För lågt!";
                    if (!SecretNumber.CanMakeGuess)
                    {
                        GuessOutcome.Text += string.Format("\n✘ Du har inga fler gissningar. Det hemliga talet var {0}.", SecretNumber.Number);
                        GuessInput.Enabled = false;
                        MakeGuess.Enabled = false;
                        NewNumber.Visible = true;
                    }
                }
                else if (result == Outcome.High)
                {
                    GuessOutcome.Text += " ⇧ För högt!";
                    if (!SecretNumber.CanMakeGuess)
                    {
                        GuessOutcome.Text += string.Format("\n✘ Du har inga fler gissningar. Det hemliga talet var {0}.", SecretNumber.Number);
                        GuessInput.Enabled = false;
                        MakeGuess.Enabled = false;
                        NewNumber.Visible = true;
                    }
                }
                else if (result == Outcome.Correct)
                {
                    GuessOutcome.Text += string.Format(" ✔ Grattis, du klarade det på {0} försök!", SecretNumber.Count);
                    GuessInput.Enabled = false;
                    MakeGuess.Enabled = false;
                    NewNumber.Visible = true;
                }
                else if (result == Outcome.PreviousGuess)
                {
                    GuessOutcome.Text += " ⚠ Du har redan gissat på det!";
                }
            }
        }

        protected void NewNumber_Click(object sender, EventArgs e)
        {
            Session.Clear(); //skapa ny session
            Response.Redirect("Default.aspx"); //ladda om sidan
        }
    }
}