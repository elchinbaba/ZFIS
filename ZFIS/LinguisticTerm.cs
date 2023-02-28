namespace ZFIS
{
    public class _LinguisticTerm
    {
        public _ZNumber3 Value;
        public string Label;
        
        public _LinguisticTerm(_ZNumber3 val, string lab)
        {
            Value=val;
            Label=lab;
        }
        
        public _LinguisticTerm(_ZNumber3 val)
        {
            Value=val;
            Label= ""+val.ToString();
        }
        
        public _LinguisticTerm(double val)
        {
            Value= new _ZNumber3(val);
            Label=""+val;
        }
    }
}