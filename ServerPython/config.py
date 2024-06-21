class Config:
    """ Class to manage application configurations.
        Provides access to host, port, and URL settings used by various services."""
    
    # INDIRIZZI
    HOST_KEY = 'host'
    PORT_KEY_5000 = 'port_5000'
    PORT_KEY_8080 = 'port_8080'

    CONFIG = {
        HOST_KEY: "localhost",
        PORT_KEY_5000: 5000,
        PORT_KEY_8080: 8080  
    }

  
    def get_host(self):
        """ Returns the configured host."""
        return self.CONFIG[self.HOST_KEY]
    
    # C#
    def get_port_8080(self):  
        """Returns the port configured for the service in C#."""
        return self.CONFIG[self.PORT_KEY_8080]

    # Go
    def get_port_5000(self):  
        """ Returns the port configured for the service in Go."""
        return self.CONFIG[self.PORT_KEY_5000]  
    
    # Url
    """ Return the URL for the endpoints"""
    def get_url_receive_category(self):
        host = self.get_host()
        port = self.get_port_5000()
        return f'http://{host}:{port}/receive-category'
    
    def get_url_receive_text(self):
        host = self.get_host()
        port = self.get_port_5000()
        return f'http://{host}:{port}/receive-text'
    
    def get_url_text_list(self):
        host = self.get_host()
        port = self.get_port_5000()
        return f'http://{host}:{port}/text-list'
    
    def get_url_rate_list(self):
        host = self.get_host()
        port = self.get_port_5000()
        return f'http://{host}:{port}/rate-list'

    def get_url_text_comparison(self):
        host = self.get_host()
        port = self.get_port_5000()
        return f'http://{host}:{port}/text-comparison'
        