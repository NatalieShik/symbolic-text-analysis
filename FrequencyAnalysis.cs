namespace SecondVersion
{
    internal class FrequencyAnalysis
    {
        protected internal string Symbol { get; }   //свойство, хранящее символ или его название (в случае пробела)
        protected internal int Absolutefrequency { get; }   //свойство, хранящее абсолютную частоту встречаемости, то есть сколько раз символ встретился в тексте
        protected internal double Relativefrequency { get; }    //свойство, хранящее относительную частоту в процентах, то есть умноженное на 100 отношение абсолютной встречаемости к общему числу символов
        protected internal string ToolTipText { get; }  //свойство, хранящее подсказку к символу (в большинстве случаев код в Юникоде)
        public FrequencyAnalysis(string symbol, int absolutefrequency, double relativefrequency, string toolTipText)    //конструктор для создания объектов
        {
            Symbol = symbol;
            Absolutefrequency = absolutefrequency;
            Relativefrequency = relativefrequency;
            ToolTipText = toolTipText;
        }
    }
}
