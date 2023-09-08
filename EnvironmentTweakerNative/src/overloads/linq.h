#include <vector>

template <class _Ty, class _Pr>
std::vector<_Ty> find_items(std::vector<_Ty> &items, _Pr predicate)
{
    std::vector<_Ty> result;
    auto length = items.size();
    for (int i = 0; i < length; i++)
    {
        if (predicate(items[i]))
        {
            result.push_back(items[i]);
        }
    }
    return result;
}

template <class _Ty, class _Pr>
_Ty *find_item(std::vector<_Ty> &items, _Pr predicate)
{
    auto length = items.size();
    for (int i = 0; i < length; i++)
    {
        if (predicate(items[i]))
        {
            return &items[i];
        }
    }
    return nullptr;
}