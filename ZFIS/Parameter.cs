namespace ZFIS
{
    public class _Parameter
    {
        public readonly string Label;
        public readonly int NTerms;
        public readonly _LinguisticTerm[] Terms;

        public _Parameter(string lab, _LinguisticTerm[] terms)
        {
            Label=lab;
            NTerms= terms.Length;
            /*
            Terms= new _LinguisticTerm[NTerms];
            int i;
            for(i=0; i<NTerms; i++) Terms[i]= terms[i];
            */
            Terms= terms;
        }
        
        public _Parameter(string lab, int nts)
        {
            Label=lab;
            NTerms= nts;
            Terms= new _LinguisticTerm[NTerms];
            int i;
            for(i=0; i<NTerms; i++){ 
                Terms[i].Label="Label"+i;
                Terms[i].Value= new _ZNumber3(i);
            }
        }
        
        override public string ToString()
        {
            string str="";
            str+= Label+"={ ";
            int i;
            for(i=0; i<NTerms; i++){
                str+= "\""+Terms[i].Label+"\""+Terms[i].Value+"; ";
            }
            str+= " }";
            return str;
        }
        
    }
}