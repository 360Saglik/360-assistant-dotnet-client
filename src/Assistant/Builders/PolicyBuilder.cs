using Assistant.Models;

namespace Assistant.Builders;

public class PolicyBuilder
{
    private string? _description;
    private DateTime _endDate;
    private string? _group;
    private string _id;
    private string _policyNumber;
    private IList<Product>? _products;
    private DateTime _startDate;

    public static PolicyBuilder Create()
    {
        return new PolicyBuilder();
    }

    public PolicyBuilder WithId(string id)
    {
        _id = id;
        return this;
    }

    public PolicyBuilder WithPolicyNumber(string policyNumber)
    {
        _policyNumber = policyNumber;
        return this;
    }

    public PolicyBuilder WithStartDate(DateTime startDate)
    {
        _startDate = startDate;
        return this;
    }

    public PolicyBuilder WithEndDate(DateTime endDate)
    {
        _endDate = endDate;
        return this;
    }

    public PolicyBuilder WithGroup(string? group)
    {
        _group = group;
        return this;
    }

    public PolicyBuilder WithDescription(string? description)
    {
        _description = description;
        return this;
    }

    public PolicyBuilder WithProducts(IList<Product>? products)
    {
        _products = products;
        return this;
    }

    public Policy Build()
    {
        return new Policy(
            _id,
            _policyNumber,
            _startDate,
            _endDate,
            _group,
            _description,
            _products
        );
    }
}