import Vue from 'vue'
import Router from 'vue-router'
import auth from '@/utils/auth'

import Dashboard from '@/pages/Dashboard'
import About from '@/pages/About'

import Login from '@/components/Login'
import ErrorPage from '@/components/404'

Vue.use(Router)

function requireAuth (to, from, next) {
  if (!auth.loggedIn()) {
    next({
      path: '/login',
      query: { redirect: to.fullPath }
    });
  } else {
    next();
  }
}

export default new Router({
  base: __dirname,
  mode: 'history',
  scrollBehavior: () => ({ y: 0 }),
  routes: [
    { path: '/404', component: ErrorPage, name: 'ErrorPage' },
    { path: '/dashboard', component: Dashboard, name: 'Dashboard', beforeEnter: requireAuth},
    { path: '/about', component: About, name: 'About', beforeEnter: requireAuth},
    { path: '/login', component: Login, name: 'Login' },
    { path: '/logout', 
      beforeEnter (to, from, next) {
        auth.logout();
        next('/login');
      }
    },
    { path: '/', redirect: '/dashboard' },
    { path: '*', redirect: '/404' }
  ],
  meta: {
    progress: {
      func: [
        {call: 'color', modifier: 'temp', argument: '#ffb000'},
        {call: 'fail', modifier: 'temp', argument: '#6e0000'},
        {call: 'location', modifier: 'temp', argument: 'top'},
        {call: 'transition', modifier: 'temp', argument: {speed: '1.5s', opacity: '0.6s', termination: 400}}
      ]
    }
  }
})
