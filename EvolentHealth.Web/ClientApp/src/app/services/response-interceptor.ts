
import { Injectable } from '@angular/core'
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap, finalize } from 'rxjs/operators';

@Injectable()
export class ResponseInterceptor implements HttpInterceptor {
    constructor() {
    }

    request: HttpRequest<any>;
    
    private onError(err: any): Observable<any> {
        console.error(err);
        if (err instanceof HttpResponse) {
            console.log(err.status);
            console.log(err.body);
        }
        console.info("Url:" + this.request.url + " Response error count end:");
        if (err.status === 401 || err.status === 403) {
            console.log('The authentication session expires or the user is not authorised. Force refresh of the current page.');
        }

        return of(err);
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.request = req;


        return next.handle(req).pipe(

            map(resp => {
                if (resp instanceof HttpResponse) {
                }
                return resp;
            }),
            catchError(this.onError),
            finalize(() => {
                console.info("Url:" + req.url);
            })
        );



    }
}
