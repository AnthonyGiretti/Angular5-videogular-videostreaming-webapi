# Angular5-videogular-videostreaming-webapi
Example of a streaming platform built with Angular5, Videogular and a streaming ASP.NET Core Web API

Compatibility : Chrome, Firefox, Microsoft Edge

![Streaming gallery](http://anthonygiretti.com/wp-content/uploads/2018/01/runstreamingvideo-1.png)

## Set up Angular 5 with Videogular:

### Create an Angular application with the Angular CLI:
``
ng new myStreamingGallery --style=scss
``

### Now you can install the videogular2 library and core-js typings:
``
npm install videogular2 --save
npm install @types/core-js --save-dev
``

### If you want to, you can use the official Videogular font to set icons on your buttons and controls. To do that you need to add a CSS on you .angular-cli.json file available on the root of your project.
``
{
   ...
   "apps": [
       {
           ...
           "styles": [
               "../node_modules/videogular2/fonts/videogular.css",
               "styles.scss"
           ],
           ...
       }
   ],
   ...
}
``

### To start using Videogular in your project you have to add the Videogular module to your application module.

Open src/app/app.module.ts and remove the FormsModule and the HttpModule, we will not need that for this demo. This is how your app.module.ts file should like:

``import {NgModule} from "@angular/core";
import {BrowserModule} from "@angular/platform-browser";
import {VgCoreModule} from "videogular2/core";
import {VgControlsModule} from "videogular2/controls";
import {VgOverlayPlayModule} from "videogular2/overlay-play";
import {VgBufferingModule} from "videogular2/buffering";
import {AppComponent} from "./app.component";
``
``
@NgModule({
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        VgCoreModule,
        VgControlsModule,
        VgOverlayPlayModule,
        VgBufferingModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}``

For more details about Videogular you can visit the website: (Videogular)[http://videogular.github.io/videogular2/docs/]

## Set up ASP.NET Core Web API:

### Use FilStreamResult in your controller to stream a video

  ``[HttpGet("{name}")]
  public async Task<FileStreamResult> Get(string name)
  {
      var stream = await _streamingService.GetVideoByName(name);
      return new FileStreamResult(stream, "video/mp4");
   }``
     
 
Just launch the Web API and select your streamed video like this: http://localhost:{your port}/api/streaming/nature2 and http://localhost:{your port}/api/streaming/nature1

Then build your gallery! :)


