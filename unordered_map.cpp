#include <unordered_map>
#include <string>
#include <mutex>

struct Value {
    std::string data;
    // Otros miembros
};

class Cache {
private:
    std::unordered_map<std::string, Value> cache;
    std::mutex mtx;

public:
    void put(const std::string& key, const Value& value) {
        std::lock_guard<std::mutex> lock(mtx);
        cache[key] = value;
    }

    bool get(const std::string& key, Value& value) {
        std::lock_guard<std::mutex> lock(mtx);
        auto it = cache.find(key);
        if (it != cache.end()) {
            value = it->second;
            return true;
        }
        return false;
    }

    // Métodos para invalidación y caducidad
};
