namespace SharedKernel.Finances;

public sealed class MoneyValueIsLessThanZeroException()
    : Exception("The money is less than zero");
