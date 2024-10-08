import redis
import time


class DistributedCache:
    def __init__(self, host='localhost', port=6379, db=0):
        self.client = redis.StrictRedis(host=host, port=port, db=db)


    def set(self, key, value, ttl=None):
        self.client.set(key, value, ex=ttl)


    def get(self, key):
        return self.client.get(key)


    def invalidate(self, key):
        self.client.delete(key)


    def clear(self):
        self.client.flushdb()


# Ejemplo de uso
cache = DistributedCache()


# Almacenar un valor con una caducidad de 10 segundos
cache.set('my_key', 'my_value', ttl=10)


# Recuperar el valor
print(cache.get('my_key'))  # Output: b'my_value'


# Esperar 11 segundos y tratar de recuperar el valor de nuevo
time.sleep(11)
print(cache.get('my_key'))  # Output: None
