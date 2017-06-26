export class App {
  configureRouter(config, router) {
    config.title = 'Smart SMS';
    config.map([
      { route: ['', 'mesajes'], name: 'messages',      moduleId: 'pages/messages/index',      nav: true, title: 'Mensajes' },
      { route: 'contactos',         name: 'contacts',        moduleId: 'pages/contacts/index',        nav: true, title: 'Contactos' },
      { route: 'otros',         name: 'others',        moduleId: 'pages/others/index',        nav: true, title: 'Otros' },
    ]);

    this.router = router;
  }
}
