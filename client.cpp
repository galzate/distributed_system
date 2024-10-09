#include <boost/asio.hpp>
using boost::asio::ip::tcp;

void client() {
    boost::asio::io_service io_service;
    tcp::resolver resolver(io_service);
    tcp::resolver::query query("localhost", "12345");
    tcp::resolver::iterator endpoint_iterator = resolver.resolve(query);
    tcp::socket socket(io_service);
    boost::asio::connect(socket, endpoint_iterator);
    // Interactuar con el servidor (Enviar/Recibir claves/valores de la caché)
}
