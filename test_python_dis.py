import unittest
from your_cache_module import DistributedCache

class TestDistributedCache(unittest.TestCase):
    def setUp(self):
        self.cache = DistributedCache()

    def test_set_and_get(self):
        self.cache.set('test_key', 'test_value', ttl=5)
        self.assertEqual(self.cache.get('test_key'), b'test_value')

    def test_invalidate(self):
        self.cache.set('test_key', 'test_value')
        self.cache.invalidate('test_key')
        self.assertIsNone(self.cache.get('test_key'))

    def test_clear(self):
        self.cache.set('test_key1', 'test_value1')
        self.cache.set('test_key2', 'test_value2')
        self.cache.clear()
        self.assertIsNone(self.cache.get('test_key1'))
        self.assertIsNone(self.cache.get('test_key2'))

if __name__ == '__main__':
    unittest.main()

