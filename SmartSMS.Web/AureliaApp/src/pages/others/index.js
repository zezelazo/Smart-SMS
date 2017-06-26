export class Index{
   heading = 'Otros';

 configureRouter(config, router) {
    config.map([
      { route: ['', 'acerca de'], name: 'about', moduleId: 'pages/others/about', nav: true, title: 'About' },
      { route: 'levels', name: 'levels', moduleId: 'pages/others/levels', nav: true, title: 'Niveles' },
      { route: 'grades', name: 'grades', moduleId: 'pages/others/grades', nav: true, title: 'Grados' },
      { route: 'classes', name: 'classes', moduleId: 'pages/others/classes', nav: true, title: 'Clases' }
    ]);

    this.router = router;
  }
}