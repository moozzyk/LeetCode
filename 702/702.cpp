// Forward declaration of ArrayReader class.
class ArrayReader;

class Solution {

public:
    int search(const ArrayReader& reader, int target) {
        auto left = 0;
        auto right = 2147483647;

        while (left <= right)
        {
            auto mid = left + (right - left) / 2;
            auto x = reader.get(mid);

            if (x == target)
            {
                return mid;
            }

            if (x > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return -1;
    }
};