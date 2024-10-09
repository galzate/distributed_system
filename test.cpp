#include <gtest/gtest.h>
#include "cache.h"

TEST(CacheTest, PutAndGet) {
    Cache cache;
    Value value = {"data"};
    cache.put("key", value);

    Value retrieved;
    ASSERT_TRUE(cache.get("key", retrieved));
    ASSERT_EQ(retrieved.data, "data");
}

int main(int argc, char **argv) {
    ::testing::InitGoogleTest(&argc, argv);
    return RUN_ALL_TESTS();
}
