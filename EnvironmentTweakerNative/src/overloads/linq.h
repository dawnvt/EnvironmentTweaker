#include <vector>

template <class T, class _Pr>
std::vector<T> find_items(std::vector<T> const &items, _Pr predicate)
{
    std::vector<T> result;
    auto it = items.begin();
    while ((it = std::find_if(it, items.end(), predicate)) != items.end())
    {
        result.push_back(*it);
        it++;
    }
    return result;
}