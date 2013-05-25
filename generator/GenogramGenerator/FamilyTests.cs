﻿using System.Linq;
using NUnit.Framework;

namespace GenogramGenerator
{
    [TestFixture]
    public class FamilyTests
    {
        //Data excerpted from http://www.rhettsmith.com/wp-content/uploads/2013/03/Kennedy-Geno.jpg
        private Person john,joe,rosemary,jackie,jackiesSecondHusband,kathleen,eunice,pat,robert,jean,ted,
            miscarriage,daughter1,daughter2,son1,son2,kathleensHusband,kathleensSecondHusband,ethyl,rdaughter1,rson1,rson2,rson3,rdaughter2,rson4,rdaugher3,rson5,rson6,rson7,rdaugher4,
            joseph,rose,gloria,patrick,patricksWife,pdaughter1,pdaughter2,fitz,mary,toodles,fdaughter2,fson1,fson2,fdaughter3,fson3;
        Family kennedy;

        [SetUp]
        public void Setup()
        {
            kennedy = new Family();
            john = kennedy.Add("John"); joe = kennedy.Add("Joe"); rosemary = kennedy.Add("Rosemary"); jackie = kennedy.Add("Jackie"); jackiesSecondHusband = kennedy.Add("JackiesSecondHusband");
            kathleen = kennedy.Add("Kathleen"); eunice = kennedy.Add("Eunice"); pat = kennedy.Add("Pat"); robert = kennedy.Add("Robert"); jean = kennedy.Add("Jean"); ted = kennedy.Add("Ted");
            miscarriage = kennedy.Add("miscarriage"); daughter1 = kennedy.Add("daughter1"); daughter2 = kennedy.Add("daughter2"); son1 = kennedy.Add("son1"); son2 = kennedy.Add("son2");
            kathleensHusband = kennedy.Add("KathleensHusband"); kathleensSecondHusband = kennedy.Add("KathleensSecondHusband");
            ethyl = kennedy.Add("Ethyl"); rdaughter1 = kennedy.Add("rdaughter1"); rson1 = kennedy.Add("rson1"); rson2 = kennedy.Add("rson2"); rson3 = kennedy.Add("rson3"); 
            rdaughter2 = kennedy.Add("rdaughter2"); rson4 = kennedy.Add("rson4"); rdaugher3 = kennedy.Add("rdaugher3"); rson5 = kennedy.Add("rson5"); rson6 = kennedy.Add("rson6");
            rson7 = kennedy.Add("rson7"); rdaugher4 = kennedy.Add("rdaugher4"); 
            joseph = kennedy.Add("Joseph"); rose = kennedy.Add("Rose"); gloria = kennedy.Add("Gloria"); patrick = kennedy.Add("Patrick"); patricksWife = kennedy.Add("PatricksWife");
            pdaughter1 = kennedy.Add("pdaughter1"); pdaughter2 = kennedy.Add("pdaughter2"); fitz = kennedy.Add("Fitz"); mary = kennedy.Add("Mary"); toodles = kennedy.Add("Toodles");
            fdaughter2 = kennedy.Add("fdaughter2"); fson1 = kennedy.Add("fson1"); fson2 = kennedy.Add("fson2"); fdaughter3 = kennedy.Add("fdaughter3"); fson3 = kennedy.Add("fson3");

            john.Is.TheChildOf(rose, joseph);
            john.Is.MarriedTo(jackie);
            jackie.Is.MarriedTo(jackiesSecondHusband);
            miscarriage.Is.TheChildOf(john, jackie);
            daughter1.Is.TheChildOf(john, jackie);
            daughter2.Is.TheChildOf(john, jackie);
            son1.Is.TheChildOf(john, jackie);
            son2.Is.TheChildOf(john, jackie);
            joe.Is.TheChildOf(rose, joseph);
            rosemary.Is.TheChildOf(rose, joseph);
            kathleen.Is.TheChildOf(rose, joseph);
            kathleen.Is.MarriedTo(kathleensHusband);
            kathleen.Is.MarriedTo(kathleensSecondHusband);
            eunice.Is.TheChildOf(rose, joseph);
            pat.Is.TheChildOf(rose, joseph);
            robert.Is.TheChildOf(rose, joseph);
            robert.Is.MarriedTo(ethyl);
            rdaughter1.Is.TheChildOf(ethyl, robert);
            rson1.Is.TheChildOf(ethyl, robert);
            rson2.Is.TheChildOf(ethyl, robert);
            rson3.Is.TheChildOf(ethyl, robert);
            rdaughter2.Is.TheChildOf(ethyl, robert);
            rson4.Is.TheChildOf(ethyl, robert);
            rdaugher3.Is.TheChildOf(ethyl, robert);
            rson5.Is.TheChildOf(ethyl, robert);
            rson6.Is.TheChildOf(ethyl, robert);
            rson7.Is.TheChildOf(ethyl, robert);
            rdaugher4.Is.TheChildOf(ethyl, robert);
            jean.Is.TheChildOf(rose, joseph);
            ted.Is.TheChildOf(rose, joseph);
            joseph.Is.MarriedTo(rose);
            joseph.Is.TheChildOf(patricksWife, patrick);
            pdaughter1.Is.TheChildOf(patricksWife, patrick);
            pdaughter2.Is.TheChildOf(patricksWife, patrick);
            rose.Is.TheChildOf(mary, fitz);
            fitz.Is.MarriedTo(mary);
            fdaughter2.Is.TheChildOf(mary, fitz);
            fson1.Is.TheChildOf(mary, fitz);
            fson2.Is.TheChildOf(mary, fitz);
            fdaughter3.Is.TheChildOf(mary, fitz);
            fson3.Is.TheChildOf(mary, fitz);
            gloria.Is.TheRomanticPartnerOf(joseph);
            toodles.Is.TheRomanticPartnerOf(fitz);
        }

        [Test]
        public void FindSiblings()
        {
            var rosesSiblings = kennedy.SiblingsOf(rose);
            Assert.That(rosesSiblings.Count(), Is.EqualTo(5));
            Assert.That(rosesSiblings, Has.Member(fdaughter2));
            Assert.That(rosesSiblings, Has.Member(fson1));
            Assert.That(rosesSiblings, Has.Member(fson2));
            Assert.That(rosesSiblings, Has.Member(fdaughter3));
            Assert.That(rosesSiblings, Has.Member(fson3));
        }

        [Test]
        public void FamilyMembersShouldBeAUniqueList()
        {
            Assert.That(kennedy.Members().Count(), Is.EqualTo(45));
        }

        //finding children of two parents
        //what if you ask for the children of two people who didn't have children together? you'll get false results.
        //finding children of a person
    }
}